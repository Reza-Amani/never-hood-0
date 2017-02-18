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
        public WorldForm()
        {
            InitializeComponent();
        }
        public PictureBox get_picture_box()
        {
            return WorldPictureBox;
        }
    }
}
