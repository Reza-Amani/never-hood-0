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
            bm = new Bitmap(10, 10);

        }
        Bitmap bm;
        public void update()
        {
            p = new Pen(Brushes.Aqua);
            r = new Rectangle(0, 0, 20,10);
            g.DrawRectangle(p, r);
            p.Brush = Brushes.Black;
            g.DrawEllipse(p, 20, 20, 30, 30);

            Color color = Color.DarkRed;
            bm.SetPixel(0, 0, color);
            g.DrawImageUnscaled(bm, 50, 50);
            box.Image = btm;
        }
        public void step_test()
        {
            r.X += 10;
            g.DrawRectangle(p, r);
            box.Image = btm;
        }
    }
}
