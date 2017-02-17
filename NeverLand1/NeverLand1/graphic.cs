using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace NeverLand1
{
    class graphic
    {
        Graphics g;
        Bitmap btm;
        PictureBox box;

        Rectangle r;
        Pen p;
        public graphic(PictureBox picture_box)
        {
            box = picture_box;
            btm = new Bitmap(box.Width, box.Height);
            g = Graphics.FromImage(btm);  //graphics for a boundary
            box.Image = btm;
            bms = new Bitmap[1000];
            Color color = Color.DarkRed;
            for (int i = 0; i < 1000; i++)
            {
                bms[i] = new Bitmap(2, 2);
                bms[i].SetPixel(0, 0, color);
            }

        }
        Bitmap[] bms;
        public void draw_shapes()
        {
            p = new Pen(Brushes.Aqua);
            r = new Rectangle(0, 0, 20, 10);
            g.DrawRectangle(p, r);
            p.Brush = Brushes.Black;
            g.DrawEllipse(p, 20, 20, 30, 30);
            g.DrawEllipse(p, 30, 30, 40, 40);
            box.Image = btm;
        }
        public void update()
        {
            
        }
        public void step_test()
        {
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
                g.DrawImageUnscaled(bms[i], rnd.Next(500), rnd.Next(500));
            box.Image = btm;
        }
    }
}
