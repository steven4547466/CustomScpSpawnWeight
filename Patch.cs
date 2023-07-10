using HarmonyLib;
using NorthwoodLib.Pools;
using PlayerRoles;
using PlayerRoles.RoleAssign;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static HarmonyLib.AccessTools;

namespace CustomScpSpawnWeight
{
    [HarmonyPatch(typeof(ScpSpawner), nameof(ScpSpawner.NextScp), MethodType.Getter)]
    internal class Patch
    {
        private static float GetNewWeight(float cur, PlayerRoleBase playerRoleBase)
        {
            return cur == 0f ? 0f : (Plugin.Singleton.Config.SpawnWeights.TryGetValue(playerRoleBase.RoleTypeId, out SpawnWeight weight) ? (weight.Weight == -1 ? cur : weight.Weight) : cur);
        }

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);
            int index = newInstructions.FindLastIndex(c => c.opcode == OpCodes.Call && (MethodInfo)c.operand == Method(typeof(Mathf), nameof(Mathf.Max), new[] { typeof(float), typeof(float) })) + 1;

            newInstructions.InsertRange(index, new[]
            {
                new CodeInstruction(OpCodes.Ldloc_S, 4).MoveLabelsFrom(newInstructions[index]),
                new CodeInstruction(OpCodes.Call, Method(typeof(Patch), nameof(Patch.GetNewWeight)))
            });

            for (int z = 0; z < newInstructions.Count; z++) yield return newInstructions[z];

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }
    }
}
