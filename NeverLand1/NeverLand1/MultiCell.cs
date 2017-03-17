using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    class MultiCell:Creature
    {
        DNA_MultiCell DNAold;
        DNA DNA;
        MultiCell(int _x, int _y, DNA _DNA, int _age, int _hump, int _name)
        {
            x = _x; y = _y;DNA = _DNA; age = _age; hump = _hump;
            face = new Bitmap(2, 2);
            update_face();
            to_dye = false;
            name = _name;
        }
        public int days_from_last_reproduction=0;
        public const int absolute_max_age = 1000;

        override protected void update_face()
        {
            if (DNAold.cholorophyl && DNAold.mouth)
                face.SetPixel(0, 0, Color.Yellow);
            else if (DNAold.cholorophyl)
                face.SetPixel(0, 0, Color.Green);
            else if (DNAold.mouth)
                face.SetPixel(0, 0, Color.Red);
            else if (!DNAold.mouth && !DNAold.cholorophyl)
                face.SetPixel(0, 0, Color.White);

            if (DNAold.crawling_leg)
                face.SetPixel(0, 1, Color.Black);
            else
                face.SetPixel(0, 1, Color.Gray);

            if (DNAold.fin)
                face.SetPixel(1, 0, Color.DarkBlue);
            else
                face.SetPixel(1, 0, Color.Gray);

            if (DNAold.genital_female && DNAold.genital_male)
                face.SetPixel(1, 1, Color.Violet);
            else if (DNAold.genital_female)
                face.SetPixel(1, 1, Color.Pink);
            else if (DNAold.genital_male)
                face.SetPixel(1, 1, Color.Brown);
            else if (!DNAold.genital_female && !DNAold.genital_male)
                face.SetPixel(1, 1, Color.Gray);

        }
        override protected void choose_next_pixel(int _x, int _y, out int _new_x, out int _new_y)
        {
            _new_x = 0;
            _new_y = 0;
        }

        override protected void reproduce(ref int _new_x, ref int _new_y)
        {
        }
        override protected void move_eat(int _new_x, int _new_y)
        {
        }
        override protected void metabolism()
        {
        }
        override protected void mutation()
        {
        }
    }
}
