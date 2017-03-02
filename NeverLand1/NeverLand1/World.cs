using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class World
    {
        public WorldPoint[,] PointsArray = new WorldPoint[Globals.world_x_size, Globals.world_y_size];
        graphic graph;
        Random random_generator;
        public List<SingleCell> cells = new List<SingleCell>();
        static int calendar = 0;
        public int cell_ID = 0;
        SingleCell selected_cell;

        public World(graphic _g,Random _rnd)
        {
            for (int i = 0; i < Globals.world_x_size; i++)
                for (int j = 0; j < Globals.world_y_size; j++)
                    PointsArray[i, j] = new WorldPoint(WaterType._coastal_water, 0, null);
            graph = _g;
            random_generator = _rnd;
            SingleCell.world = this;
        }

        public void add_new_cell(int _x, int _y, SingleCell _cell)
        {
            cells.Add(_cell);
            PointsArray[_x, _y].cell = _cell;
        }

        public bool kill_cell(SingleCell _cell)
        {
            if (selected_cell == _cell)
                selected_cell = null;
            PointsArray[_cell.x, _cell.y].cell = null;
            if(!cells.Remove(_cell))
                return false; //error, no cell
            if (cells.Remove(_cell))
                return false;   //error, double cell!
            return true;
        }
        public void update_1day()
        {
            calendar++;
            for (int i = cells.Count - 1; i >= 0; i--)
                cells[i].Update_1day();
/*            for (int i = cells.Count - 1; i >= 0; i--)
                if (cells[i].to_dye)
                {
                    if(selected_cell == cells[i])
                        selected_cell = null;
                    PointsArray[cells[i].x, cells[i].y].cell = null;
                    cells.RemoveAt(i);
                    
                }
  */
        }

        public void update_graphics()
        {
            graph.reset_world_view();
            for (int i = cells.Count - 1; i >= 0; i--)
                graph.draw_bmp(cells[i].face, cells[i].x, cells[i].y);
            graph.update_world_view();
        }

        public string get_point_info(int _x, int _y)
        {
            string result = "x: " + _x.ToString();
            result += "\r\ny: " + _y.ToString();
            result += "\r\norganics: " + PointsArray[_x, _y].organics.ToString();
            result += "\r\ncell: " + ((PointsArray[_x, _y].cell == null) ? "nobody" : PointsArray[_x, _y].cell.name.ToString());
            if (PointsArray[_x, _y].cell != null)
                selected_cell = PointsArray[_x, _y].cell;
            return result;
        }
        public string get_world_info()
        {
            string result = "world age: " + calendar.ToString();
            result += "\r\ncells population: " + cells.Count.ToString();
            return result;
        }
        public string get_cell_info()
        {
            string result = ""; 
            if (selected_cell == null)
                if(cells.Count>0)
                    selected_cell = cells[0];
            if (selected_cell != null)
            {
                result = "cell name: " + selected_cell.name;
                result += "\r\n age: " + selected_cell.age.ToString();
                result += "\r\n x: " + selected_cell.x.ToString();
                result += "\r\n y: " + selected_cell.y.ToString();
                result += "\r\n hump: " + selected_cell.hump.ToString();
                result += "\r\n max_age: " + selected_cell.age_max.ToString();
                result += "\r\n breed at: " + selected_cell.breeding_thresh.ToString();
            }
            return result;
        }
    }
}
