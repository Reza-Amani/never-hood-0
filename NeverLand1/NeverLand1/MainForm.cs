using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NeverLand1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Graphics g;
        Bitmap btm;

        Rectangle r;
        Pen p;

        public void start_graphic()
        {
            btm = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            g = Graphics.FromImage(btm);  //graphics for a boundary
            pictureBoxMain.Image = btm;
        }

        private void test_Click(object sender, EventArgs e)
        {
            start_graphic();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Pen(Brushes.Aqua);
            r = new Rectangle(0, 0, 20,10);
            g.DrawRectangle(p, r);
            p.Brush = Brushes.Black;
            g.DrawEllipse(p, 20, 20, 30, 30);
            pictureBoxMain.Image = btm;
        }
    }
}
