using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class WorldPoint
    {
        public WaterType water;
        public int organics;
        public SingleCell cell;
        public MultiCell multi_cell;
        public WorldPoint(WaterType _water, int _organics, SingleCell _cell, MultiCell _multi)
        {
            water = _water; organics = _organics; cell = _cell; multi_cell=_multi;
        }
        public int get_sun_energy()
        {
            switch (water)
            {
                case WaterType._deep_water:
                    return 1;
                case WaterType._shallow_water:
                    return 2;
                case WaterType._coastal_water:
                    return 3;
                case WaterType._dry:
                    return 4;
                default:
                    return 0;

            }
        }
        
    }
}
