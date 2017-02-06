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
            graph = new graphic(pictureBoxMain);
        }
        graphic graph;

        private void test_Click(object sender, EventArgs e)
        {
            graph.update();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
