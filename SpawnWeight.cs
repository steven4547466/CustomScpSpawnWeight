using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomScpSpawnWeight
{
    public class SpawnWeight
    {
        public float Weight { get; set; }

        public SpawnWeight(float weight) 
        {
            Weight = weight;
        }

        public SpawnWeight() { }
    }
}
