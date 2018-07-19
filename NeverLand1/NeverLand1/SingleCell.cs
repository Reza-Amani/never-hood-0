using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    [Serializable]
    class SingleCell:Creature
    {
        public int breeding_thresh,age_max;
        public FoodType food_type;
//        Gene gene = new Gene() { absolute_min = 2 };
        public SingleCell(int x_, int y_, FoodType food_type_, int breeding_thresh_, int age_max_, int hump_, int age_, int _name)
        {
            x = x_; y = y_; food_type = food_type_; breeding_thresh = breeding_thresh_; age_max = age_max_; hump = hump_; age = age_;
            size = 1;
            face = new Bitmap(size, size);
            update_face();
            to_dye = false;
            name = _name;
        }
        public SingleCell()
        {
            size = 1;
        }
        override protected void update_face()
        {
            switch (food_type)
            {
                case FoodType._sun_light:
                    face.SetPixel(0, 0, Color.Green);
                    break;
                case FoodType._organics:
                    face.SetPixel(0, 0, Color.Black);
                    break;
                case FoodType._single_cell:
                    face.SetPixel(0, 0, Color.DarkRed);
                    break;
            }
        }

        override protected void update_organs_from_genume() { }
        override protected void update_parameters_from_pargenume() { }
        override protected void choose_next_pixel(int _x, int _y, out int _new_x, out int _new_y)
        {
            int newx = _x + Globals.get_random_int_inc(-1, 1);
            int newy = _y + Globals.get_random_int_inc(-1, 1);
            if ((newx < world.coast_line) && (newx >= 0) && (newy < Globals.world_y_size) && (newy >= 0))
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
        override protected void reproduce(ref int _new_x, ref int _new_y)
        {
            if(hump>breeding_thresh)
                if (world.PointsArray[_new_x, _new_y].cell == null)
                {
                    hump -= breeding_thresh / 2;
                    SingleCell _new_born = new SingleCell(_new_x, _new_y, food_type, breeding_thresh, age_max, breeding_thresh / 2, 0, world.cell_ID++);
                    world.add_new_cell(_new_x, _new_y, _new_born);
                    _new_x = x;
                    _new_y = y;
                }
        }
        override protected void move_eat(int _new_x, int _new_y)
        {
            switch (food_type)
            {
                case FoodType._sun_light:
                    if (world.PointsArray[_new_x, _new_y].cell == null)
                        do_move(_new_x, _new_y);
                    hump += world.PointsArray[x, y].get_sun_energy();
                    break;
                case FoodType._organics:
                    if (world.PointsArray[_new_x, _new_y].cell == null)
                        do_move(_new_x, _new_y);
                    int amount_to_eat = Math.Min(world.PointsArray[x, y].organics, 8);
                    hump += amount_to_eat;
                    world.PointsArray[x, y].organics -= amount_to_eat;
                    break;
                case FoodType._single_cell:
                    if (world.PointsArray[_new_x, _new_y].cell == null)
                        do_move(_new_x, _new_y);
                    else 
                        if( (hump > world.PointsArray[_new_x, _new_y].cell.hump)
                            &&(world.PointsArray[_new_x, _new_y].cell.food_type!=FoodType._single_cell) )
                        {   //if target cell is smaller
                            hump += world.PointsArray[_new_x, _new_y].cell.hump;
                            world.PointsArray[_new_x, _new_y].cell.hump = 0;
                            world.PointsArray[_new_x, _new_y].cell.to_dye = true;
                        }
                    break;
            }
        }

        override protected void metabolism()
        {
            if (age > age_max)
            {   //checking age_max
                world.PointsArray[x, y].organics += hump;
                hump = 0;
                to_dye = true;
                return;
            }
            if (hump >= 2)
            {   //checking starving
                hump -= 2;
                world.PointsArray[x, y].organics += 2;
            }
            else
            {   //starving
                world.PointsArray[x, y].organics += hump;
                hump = 0;
                to_dye = true;
            }
        }

        override protected void mutation()
        {
            if (Globals.get_random_int_inc(0,100) == 1)
                switch (Globals.get_random_int_inc(0,3))
                {
                    case 0: 
                        breeding_thresh = Globals.mutate(breeding_thresh,10,-10,Globals.default_cell_breed_thresh_max,10);
                        break;
                    case 1: 
                        age_max = Globals.mutate(age_max,10,-10,Globals.default_cell_max_age_max,10);
                        break;
                    case 2:
                        if (Globals.get_random_int_inc (0,1) == 0)
                            food_type = Globals.get_next_foodtype(food_type);
                        else
                            food_type = Globals.get_prev_foodtype(food_type);
                        break;
                    case 3:
                        if ((x < Globals.world_x_size - size) && (x >= 0) && (y < Globals.world_y_size - size) && (y >= 0))
                        {
                            MultiCell new_multi = new MultiCell(x, y, new DNA(this), age, hump, world.multi_ID);
                            world.add_new_multi(x, y, new_multi);
                            hump = 0;
                            to_dye = true;
                        }
                        break;
                }
        }

        void do_move(int _newx, int _newy)
        {
            world.PointsArray[x, y].cell = null;
            world.PointsArray[_newx, _newy].cell = this;
            x = _newx;
            y = _newy;
        }
    }
}
