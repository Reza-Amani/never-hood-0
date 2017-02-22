using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class WorldPoint
    {
        WaterType water;
        int organics;
        public SingleCell cell;
        public WorldPoint(WaterType _water, int _organics, SingleCell _cell)
        {
            water = _water; organics = _organics; cell = _cell;
        }
        
    }
}
