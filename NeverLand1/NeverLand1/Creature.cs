using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    class Creature
    {
        public int x, y, hump, age;
        protected static Random random_generator = new Random();
        static public World world;
        public Bitmap face;
        public bool to_dye;
        public int name;

        virtual public void Update_1day()
        {
        }
    }
}
