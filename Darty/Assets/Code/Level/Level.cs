using Assets.Code.Spawner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Level
{
    [Serializable]
    public class Level
    {
        public int LevelNo;
        public bool Completed;
        public SpawnSet[] Spawns;
    }
}
