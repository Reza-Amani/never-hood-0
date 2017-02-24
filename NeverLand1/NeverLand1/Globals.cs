using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    enum FoodType { _sun_light, _organics, _single_cell };
    enum WaterType { _dry, _coastal_water, _shallow_water, _deep_water };
    public class Globals
    {
        public const int world_x_size = 500, world_y_size = 500;
        public const int width_deep_water = 50, width_shallow_water = 100, width_coastal_water = 300, width_dry = world_x_size;
    }
}
