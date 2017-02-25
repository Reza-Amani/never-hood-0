using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    class SingleCell
    {
        public SingleCell(int x_, int y_, FoodType food_type_, int breeding_thresh_, int age_max_, int hump_, int age_, Random _rnd, int _name, WorldPoint[,] _world_points)
        {
            x = x_; y = y_; food_type = food_type_; breeding_thresh = breeding_thresh_; age_max = age_max_; hump = hump_; age = age_;
            face = new Bitmap(2, 2);
            update_face();
            random_generator = _rnd;
            world_points = _world_points;
            to_dye = false;
            name = _name;
        }

        public int x,y,breeding_thresh,age_max,hump,age;
        Random random_generator;
        FoodType food_type;
        public Bitmap face;
        WorldPoint[,] world_points;
        public bool to_dye;
        public int name; 
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
            int new_x, new_y;
            decide_move_random_1pixel(x,y,out new_x, out new_y);

            if (world_points[new_x, new_y].cell == null)
                do_move(new_x, new_y);

            return true;
        }
        void decide_move_random_1pixel(int _x, int _y, out int _new_x, out int _new_y)
        {
            int newx = _x + random_generator.Next(-1, 2);
            int newy = _y + random_generator.Next(-1, 2);
            if ((newx < Globals.width_dry) && (newx >= 0) && (newy < Globals.world_y_size) && (newy >= 0))
            {   //propose new point 
                _new_x = newx;
                _new_y = newy;
            }
            else
            {   //new point out of border, stay still
                _new_x = _x;
                _new_y = _y;
            }
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
