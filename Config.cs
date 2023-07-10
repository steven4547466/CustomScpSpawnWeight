using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomScpSpawnWeight
{
    public sealed class Config
    {
        public Dictionary<RoleTypeId, SpawnWeight> SpawnWeights { get; set; } = new Dictionary<RoleTypeId, SpawnWeight>()
        {
            {
                RoleTypeId.Scp049,
                new SpawnWeight(-1)
            },
            {
                RoleTypeId.Scp079,
                new SpawnWeight(-1)
            },
            {
                RoleTypeId.Scp096,
                new SpawnWeight(-1)
            },
            {
                RoleTypeId.Scp106,
                new SpawnWeight(-1)
            },
            {
                RoleTypeId.Scp173,
                new SpawnWeight(-1)
            },
            {
                RoleTypeId.Scp939,
                new SpawnWeight(-1)
            }
        };
    }
}
