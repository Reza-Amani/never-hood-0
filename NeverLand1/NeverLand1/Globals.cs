using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    public enum FoodType { _sun_light, _organics, _single_cell };
    public enum WaterType { _dry, _coastal_water, _shallow_water, _deep_water };
    public static class Globals
    {
        public const int world_x_size = 500, world_y_size = 500;
        public const int default_cell_max_age = 200, default_cell_max_age_max = 1000, default_cell_breed_thresh = 80, default_cell_breed_thresh_max = 800;
        public const int width_deep_water = 50, width_shallow_water = 100, width_coastal_water = 300;

        static Random random_generator = new Random();

        public static int mutate(int _input, int _percent_plus, int _percent_minus, int _max, int _min)
        {
            lock (random_generator)
                _input = ( _input*( random_generator.Next(_percent_minus, _percent_plus + 1)+100 ) ) / 100;
            if (_input < _min)
                _input = _min;
            if (_input > _max)
                _input = _max;
            return _input;
        }
        public static bool get_random_bool()
        {
            lock (random_generator)
                return (random_generator.Next(0, 2) == 0);
        }
        public static int get_random_int_inc(int min, int max)
        {
            if (min > max)
            {   //don't worry if the order is not correct
                int temp = max;
                max = min;
                min = temp;
            }
            lock (random_generator)
                return random_generator.Next(min, max + 1);
        }
        public static FoodType get_next_foodtype(FoodType _current_type)
        {
            switch (_current_type)
            {
                case FoodType._sun_light:
                    return FoodType._organics;
                case FoodType._organics:
                    return FoodType._single_cell;
                default:
                    return FoodType._single_cell;
            }
        }
        public static FoodType get_prev_foodtype(FoodType _current_type)
        {
            switch (_current_type)
            {
                case FoodType._sun_light:
                    return FoodType._sun_light;
                case FoodType._organics:
                    return FoodType._sun_light;
                case FoodType._single_cell:
                    return FoodType._organics;
                default:
                    return FoodType._sun_light;
            }
        }
        public static void soft_error(string error_str)
        {
            
        }
        public static void hard_error(int code)
        {
            code = code + 1;
            while (true)
            {
            }

        }
    }
}
