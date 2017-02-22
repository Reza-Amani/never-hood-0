using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    class SingleCell
    {
        public SingleCell(int x_, int y_, FoodType food_type_, int breeding_thresh_, int age_max_, int hump_, int age_)
        {
            x = x_; y = y_; food_type = food_type_; breeding_thresh = breeding_thresh_; age_max = age_max_; hump = hump_; age = age_;
            face = new Bitmap(1, 1);
            update_face();
        }

        public int x,y,breeding_thresh,age_max,hump,age;
        FoodType food_type;
        Bitmap face;
        void update_face()
        {
            switch (food_type)
            {
                case FoodType._sun_light:
                    face.SetPixel(0, 0, Color.PaleGreen);
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
            return true;
        }

    }
}
