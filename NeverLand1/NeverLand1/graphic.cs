﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }
        public void draw_bmp(Bitmap _bmp,int _x,int _y)
        {
            g.DrawImageUnscaled(_bmp, _x, _y);
        }
        public void update_world_view()
        {
            box.Image = btm;
        }
        public void reset_world_view(int _coast_line)
        {
            g.FillRectangle(Brushes.DarkBlue, 0, 0, Globals.width_deep_water, Globals.world_y_size);
            g.FillRectangle(Brushes.Blue, Globals.width_deep_water, 0, Globals.width_shallow_water - Globals.width_deep_water, Globals.world_y_size);
            g.FillRectangle(Brushes.LightBlue, Globals.width_shallow_water, 0, _coast_line - Globals.width_shallow_water, Globals.world_y_size);
            g.FillRectangle(Brushes.Khaki, _coast_line, 0, Globals.world_x_size - _coast_line, Globals.world_y_size);
        }
    }
}
