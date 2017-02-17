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
            wform = new WorldForm();
            wform.Show();
            graph = new graphic(wform.get_picture_box());
        }
        graphic graph;
        WorldForm wform;

        private void test_Click(object sender, EventArgs e)
        {
            graph.update();
        }

        private void step_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                wform.Update();

                graph.step_test();
            }
        }

    }
}
