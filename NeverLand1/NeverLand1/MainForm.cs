using System;
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
        World world;
        Random random_generator = new Random();
        int point_info_x = Globals.width_shallow_water + 50, point_info_y = 50;
        static bool graphic_onoff = true;
        public MainForm()
        {
            InitializeComponent();
            wform = new WorldForm();
            wform.Show();
            graph = new graphic(wform.get_picture_box());
            world = new World(graph, random_generator);
        }

        bool TimeToGo = false;

        private void test_Click(object sender, EventArgs e)
        {
            graph.update();
        }

        private void step_Click(object sender, EventArgs e)
        {
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            TimeToGo = false;
        }

        private void button_go_Click(object sender, EventArgs e)
        {
            TimeToGo = true;
            Thread thread = new Thread(thread_go);
            thread.Start();
//            timer = new System.Threading.Timer(update_1day, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(0.5));
/*            while (TimeToGo)
            {
                world.update_1day();
            }
*/        }

        private void button_1day_Click(object sender, EventArgs e)
        {
            //update the world once
            TimeToGo = false;
            update_1day(null);
/*            world.update_1day();
            textBox_point.Text =  world.get_point_info(point_info_x, point_info_y);
            textBox_world.Text = world.get_world_info();
            textBox_cell.Text = world.get_cell_info();
*/        }

        private void thread_go()
        {
            while (TimeToGo)
            {
                Thread.Sleep(100);
                update_1day(null);
            }
        }

        private void update_1day(object state)
        {
            world.update_1day();
            if(graphic_onoff)
                world.update_graphics();
            SetText(world.get_world_info(), world.get_point_info(point_info_x, point_info_y), world.get_cell_info());
        }

        private void button_new_single_cell_Click(object sender, EventArgs e)
        {
            world.cells.Add(new SingleCell(Globals.width_shallow_water+50, 50, FoodType._sun_light, Globals.default_cell_breed_thresh, Globals.default_cell_max_age, 1, 0, world.cell_ID++));
        }

        // This method demonstrates a pattern for making thread-safe
        // calls on a Windows Forms control. 
        //
        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextCallback and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the TextBox control, the Text property is set directly. 
        delegate void SetTextCallback(string text1,string text2,string text3);
        private void SetText(string text1,string text2,string text3)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox_point.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text1,text2,text3 });
            }
            else
            {
                this.textBox_world.Text = text1;
                this.textBox_point.Text = text2;
                this.textBox_cell.Text = text3;
            }
        }

        private void button_graphic_onoff_Click(object sender, EventArgs e)
        {
            graphic_onoff = !graphic_onoff;
        }



    }
}
