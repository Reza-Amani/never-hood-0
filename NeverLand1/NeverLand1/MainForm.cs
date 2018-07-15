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
       // public static Random random_generator = new Random();
        static bool graphic_onoff = true, show_cells_onoff = true;

        Thread cells_thread, graphic_thread, UI_thread, multis_thread,corpse_cleanup_thread;
        static bool graphic_cells_needed = false, graphic_multis_needed = false, graphic_inprogress = false, cleanup_cells_needed = false, cleanup_multis_needed = false, cleanup_inprogress = false;
        
        public MainForm()
        {
            InitializeComponent();
            wform = new WorldForm();
            wform.Show();
            graph = new graphic(wform.get_picture_box());
            world = new World();
            world.set_graph(graph);

            cells_thread = new Thread(thread_cells);
            corpse_cleanup_thread = new Thread(thread_cleanup);
            multis_thread = new Thread(thread_multis);
            graphic_thread = new Thread(thread_graphic);
            UI_thread = new Thread(thread_UI);
        }

        bool TimeToGo = false;

        private void test_Click(object sender, EventArgs e)
        {
//            graphic_thread.Start();
//            go_thread.Start();
//            UI_thread.Start();
//            graph.update();
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
//            timer = new System.Threading.Timer(update_1day, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(0.5));
        }

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

        private void thread_cells()
        {
            while (true)
            {
                if (TimeToGo && !cleanup_inprogress && !cleanup_cells_needed)
                {
                    world.update_cells();// update_cells(null);
                    cleanup_cells_needed = true;
                    Thread.Sleep(1);
                    graphic_cells_needed = true;
                }
                else
                    Thread.Sleep(10);
            }
        }

        private void thread_multis()
        {
            while (true)
            {
                if (TimeToGo && !cleanup_inprogress && !cleanup_multis_needed)
                {
                    world.update_multis();// update_multis(null);
                    cleanup_multis_needed = true;
                    Thread.Sleep(1);
                    graphic_multis_needed = true;
                }
                else
                    Thread.Sleep(10);
            }
        }

        private void thread_cleanup()
        {
            while (true)
            {
                if (cleanup_cells_needed && cleanup_multis_needed && !graphic_inprogress)
                {
                    cleanup_inprogress = true;
                    world.update_cleanup_corpses();// update_cleanup(null);
                    cleanup_cells_needed = false;
                    cleanup_multis_needed = false;
                    cleanup_inprogress = false;
                }
                else
                    Thread.Sleep(10);
            }
        }

        private void thread_graphic()
        {
            while (true)
            {
                if (graphic_onoff && graphic_cells_needed && graphic_multis_needed && !cleanup_inprogress)
                {
                    graphic_inprogress = true;
                    world.update_graphics(show_cells_onoff);
                    graphic_cells_needed = false;
                    graphic_multis_needed = false;
                    graphic_inprogress = false;
                }
                else
                    Thread.Sleep(50);
            }
        }

        private void thread_UI()
        {
            while (true)
            {
                Thread.Sleep(10);
                if ( ( graphic_cells_needed || graphic_multis_needed ) && !cleanup_inprogress)
                {
                    if (wform.clicked)
                    {
                        wform.clicked = false;
                        world.wform_clicked(wform.click_x, wform.click_y);
                    }
                    SetText(world.get_world_info(), world.get_point_info(wform.click_x, wform.click_y), world.get_creature_info());
                }
            }
        }

        private void update_1day(object state)
        {
            world.update_1day();
        }

        private void button_new_single_cell_Click(object sender, EventArgs e)
        {
            if (world.PointsArray[Globals.width_shallow_water + 50, 50].cell == null)
            {
                SingleCell cell = new SingleCell(Globals.width_shallow_water + 50, 50, FoodType._sun_light, Globals.default_cell_breed_thresh, Globals.default_cell_max_age, 1, 0, world.cell_ID++);
                world.cells.Add(cell);
                world.PointsArray[Globals.width_shallow_water + 50, 50].cell = cell;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            show_cells_onoff = !show_cells_onoff;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            //BinarySerialization.WriteToBinaryFile<SingleCell>("D:/filetest.txt", world.cells[0],true);
            BinarySerialization.WriteToBinaryFile<World>("..\\..\\..\\saveworld.txt", world, false);
        }

        private void button_load_Click(object sender, EventArgs e)
        {
//            SingleCell cell = BinarySerialization.ReadFromBinaryFile<SingleCell>("D:/filetest.txt");
//            world.add_new_cell(cell.x, cell.y, cell);
            world = BinarySerialization.ReadFromBinaryFile<World>("..\\..\\..\\saveworld.txt");
            world.set_graph(graph);
            Creature.world = world;//just in case
            foreach (SingleCell cell in world.cells)
                if(cell!=null)
                    cell.after_load();
            foreach (MultiCell multi in world.multi_cells)
                if(multi!=null)
                    multi.after_load();

        }

        private void button_new_Click(object sender, EventArgs e)
        {
            world=new World();
            world.set_graph(graph);
            if (cells_thread.ThreadState == ThreadState.Unstarted)
                cells_thread.Start();
            if (multis_thread.ThreadState == ThreadState.Unstarted)
                multis_thread.Start();
            if (corpse_cleanup_thread.ThreadState == ThreadState.Unstarted)
                corpse_cleanup_thread.Start();
            if (graphic_thread.ThreadState == ThreadState.Unstarted)
                graphic_thread.Start();
            if (UI_thread.ThreadState == ThreadState.Unstarted)
                UI_thread.Start();
        }

    }
}
