using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    class MultiCell
    {
        DNA_MultiCell DNA;

        MultiCell(int _x, int _y, DNA_MultiCell _DNA, int _age, int _hump, int _name)
        {
            x = _x; y = _y;DNA = _DNA; age = _age; hump = _hump;
            face = new Bitmap(2, 2);
            update_face();
            to_dye = false;
            name = _name;
        }
        static public World world;
        public Bitmap face;

        public bool to_dye;
        public int name; 
        public int x,y,age,hump,days_from_last_reproduction=0;
        public const int absolute_max_age = 1000;

        void update_face()
        {
            if (DNA.cholorophyl && DNA.mouth)
                face.SetPixel(0, 0, Color.Yellow);
            else if (DNA.cholorophyl)
                face.SetPixel(0, 0, Color.Green);
            else if (DNA.mouth)
                face.SetPixel(0, 0, Color.Red);
            else if (!DNA.mouth && !DNA.cholorophyl)
                face.SetPixel(0, 0, Color.White);

            if (DNA.crawling_leg)
                face.SetPixel(0, 1, Color.Black);
            else
                face.SetPixel(0, 1, Color.Gray);

            if (DNA.fin)
                face.SetPixel(1, 0, Color.DarkBlue);
            else
                face.SetPixel(1, 0, Color.Gray);

            if (DNA.genital_female && DNA.genital_male)
                face.SetPixel(1, 1, Color.Violet);
            else if (DNA.genital_female)
                face.SetPixel(1, 1, Color.Pink);
            else if (DNA.genital_male)
                face.SetPixel(1, 1, Color.Brown);
            else if (!DNA.genital_female && !DNA.genital_male)
                face.SetPixel(1, 1, Color.Gray);

        }
    }
}
