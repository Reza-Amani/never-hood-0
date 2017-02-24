using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    class SingleCell
    {
        public SingleCell(int x_, int y_, FoodType food_type_, int breeding_thresh_, int age_max_, int hump_, int age_, Random _rnd, WorldPoint[,] _world_points)
        {
            x = x_; y = y_; food_type = food_type_; breeding_thresh = breeding_thresh_; age_max = age_max_; hump = hump_; age = age_;
            face = new Bitmap(2, 2);
            update_face();
            random_generator = _rnd;
            world_points = _world_points;
            to_dye = false;
        }

        public int x,y,breeding_thresh,age_max,hump,age;
        Random random_generator;
        FoodType food_type;
        public Bitmap face;
        WorldPoint[,] world_points;
        public bool to_dye;
        void update_face()
        {
            switch (food_type)
            {
                case FoodType._sun_light:
                    face.SetPixel(0, 0, Color.DarkGreen);
                    face.SetPixel(1, 0, Color.Black);
                    face.SetPixel(1, 1, Color.Black);
                    face.SetPixel(0, 1, Color.Black);
                    break;
                case FoodType._organics:
                    face.SetPixel(0, 0, Color.Gray);
                    break;
                case FoodType._single_cell:
                    face.SetPixel(0, 0, Color.DarkRed);
                    break;
            }
        }
        public bool Update_1day()
        {   //returns false if it has to be killed
            decide_move_random_1pixel();
            return true;
        }
        void decide_move_random_1pixel()
        {
            int newx = x + random_generator.Next(-1, 2);
            int newy = y + random_generator.Next(-1, 2);
            if ((newx < Globals.width_dry) && (newx >= 0))
                if ((newy < Globals.world_y_size) && (newy >= 0))
                    if (world_points[newx, newy].cell == null)
                        do_move(newx, newy);
        }
        void do_move(int _newx, int _newy)
        {
            world_points[x, y].cell = null;
            world_points[_newx, _newy].cell = this;
            x = _newx;
            y = _newy;
        }

    }
}
