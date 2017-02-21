﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NeverLand1
{
    public partial class MainForm : Form
    {
        graphic graph;
        WorldForm wform;
        World world = new World();
        public MainForm()
        {
            InitializeComponent();
            wform = new WorldForm();
            wform.Show();
            graph = new graphic(wform.get_picture_box());
        }

        private System.Threading.Timer timer;

        bool TimeToGo = false;

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

        private void button_pause_Click(object sender, EventArgs e)
        {
            TimeToGo = false;
        }

        private void button_go_Click(object sender, EventArgs e)
        {
            TimeToGo = true;
            timer = new System.Threading.Timer(update_1day, null, TimeSpan.FromSeconds(0.25), TimeSpan.FromSeconds(0.25));
/*            while (TimeToGo)
            {
                this.up
                update_1day();
            }
*/        }

        private void button_1day_Click(object sender, EventArgs e)
        {
            //update the world once
            TimeToGo = false;
            world.update_1day();
        }

        private void update_1day(object state)
        {
            //wform.Update();
            graph.step_test();
        }

        private void button_new_single_cell_Click(object sender, EventArgs e)
        {
            world.cells.Add(new SingleCell(50, 50, FoodType._sun_light, 20, 50, 1, 0));
        }

    }
}
