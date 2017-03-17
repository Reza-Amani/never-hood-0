using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    abstract class Creature
    {
        public int x, y, hump, age;
        protected static Random random_generator = new Random();
        static public World world;
        public Bitmap face;
        public bool to_dye;
        public int name;


        abstract protected void choose_next_pixel(int _x, int _y, out int _new_x, out int _new_y);
        abstract protected void update_face();
        abstract protected void reproduce(ref int _new_x, ref int _new_y);
        abstract protected void move_eat(int _new_x, int _new_y);
        abstract protected void metabolism();
        abstract protected void mutation();
        virtual public void Update_1day()
        {
            age++;
            int new_x, new_y;
            if (to_dye)
            {
                Globals.soft_error("updating dying creature");
                return;
            }
            choose_next_pixel(x, y, out new_x, out new_y);
            reproduce(ref new_x, ref new_y);
            move_eat(new_x, new_y);
            metabolism();
            if (to_dye)
                return;
            mutation();
        }
    }
}
