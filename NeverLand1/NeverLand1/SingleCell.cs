using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    class SingleCell
    {
        public int breeding_thresh,age_max;
        public FoodType food_type;

        public SingleCell(int x_, int y_, FoodType food_type_, int breeding_thresh_, int age_max_, int hump_, int age_, int _name)
        {
            x = x_; y = y_; food_type = food_type_; breeding_thresh = breeding_thresh_; age_max = age_max_; hump = hump_; age = age_;
            face = new Bitmap(1, 1);
            update_face();
            to_dye = false;
            name = _name;
        }

        static Random random_generator = new Random();
        static public World world;

        public int x,y,hump,age;
        public Bitmap face;
        public bool to_dye;
        public int name; 
        void update_face()
        {
            switch (food_type)
            {
                case FoodType._sun_light:
                    face.SetPixel(0, 0, Color.Green);
//                    face.SetPixel(1, 0, Color.Black);
//                    face.SetPixel(1, 1, Color.Black);
//                    face.SetPixel(0, 1, Color.Black);
                    break;
                case FoodType._organics:
                    face.SetPixel(0, 0, Color.Black);
                    break;
                case FoodType._single_cell:
                    face.SetPixel(0, 0, Color.DarkRed);
                    break;
            }
        }
        public void Update_1day()
        {   
            int new_x, new_y;
            if (to_dye)
            {
                Globals.soft_error(10);
                return;
            }
            age++;
            choose_next_pixel(x,y,out new_x, out new_y);
            reproduce(ref new_x, ref new_y);
            move_eat(new_x, new_y);
            metabolism();
            if (to_dye)
                return;
            mutation();
        }

        void choose_next_pixel(int _x, int _y, out int _new_x, out int _new_y)
        {
            int newx = _x + random_generator.Next(-1, 2);
            int newy = _y + random_generator.Next(-1, 2);
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
        void reproduce(ref int _new_x, ref int _new_y)
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
        void move_eat(int _new_x, int _new_y)
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
                            world.kill_cell(world.PointsArray[_new_x, _new_y].cell);
                            do_move(_new_x, _new_y);
                        }
                    break;
            }
        }

        void metabolism()
        {
            if (age > age_max)
            {   //checking age_max
                world.PointsArray[x, y].organics += hump;
                hump = 0;//!can be removed
                to_dye = true;//!can be removed
                world.kill_cell(this);
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
                world.kill_cell(this);
            }
        
        }

        void do_move(int _newx, int _newy)
        {
            world.PointsArray[x, y].cell = null;
            world.PointsArray[_newx, _newy].cell = this;
            x = _newx;
            y = _newy;
        }

        void mutation()
        {
            if(random_generator.Next(100)==1)
                switch(random_generator.Next(3))
                {
                    case 0: 
                        breeding_thresh = Globals.mutate(breeding_thresh,10,-10,100,3);
                        break;
                    case 1: 
                        age_max = Globals.mutate(age_max,10,-10,500,3);
                        break;
                    case 2: 
                        if(random_generator.Next(2)==0)
                            food_type = Globals.get_next_foodtype(food_type);
                        else
                            food_type = Globals.get_prev_foodtype(food_type);
                        break;
                }
        }
    }
}
