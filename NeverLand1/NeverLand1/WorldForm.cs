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
    public partial class WorldForm : Form
    {
        public int click_x = 150, click_y = 50;
        public bool clicked = false;
        public WorldForm()
        {
            InitializeComponent();
        }
        public PictureBox get_picture_box()
        {
            return WorldPictureBox;
        }

        private void WorldPictureBox_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                if ((mouseEventArgs.X < Globals.world_x_size) && (mouseEventArgs.Y < Globals.world_y_size))
                {
                    click_x = mouseEventArgs.X;
                    click_y = mouseEventArgs.Y;
                    clicked = true;
                }
            }
        }
    }
}
