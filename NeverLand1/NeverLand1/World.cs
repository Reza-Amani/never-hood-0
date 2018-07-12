using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    [Serializable]
    class World
    {
        public List<SingleCell> cells = new List<SingleCell>();
        public int calendar = 0;
        public int cell_ID = 0;
        SingleCell selected_cell;
        public int coast_line = Globals.width_coastal_water;

        MultiCell selected_multicell;
        public List<MultiCell> multi_cells = new List<MultiCell>();
        public WorldPoint[,] PointsArray = new WorldPoint[Globals.world_x_size, Globals.world_y_size];
        [NonSerialized]
        graphic graph;
        [NonSerialized]
        Random random_generator;

        public void set_graph_rnd(graphic _g,Random _rnd)
        {
            graph = _g;
            random_generator = _rnd;
        }
        public World()
        {
            for (int j = 0; j < Globals.world_y_size; j++)
            {
                for (int i = 0; i <= Globals.width_deep_water; i++)
                    PointsArray[i, j] = new WorldPoint(WaterType._deep_water, 0, null, null);
                for (int i = 1 + Globals.width_deep_water; i <= Globals.width_shallow_water; i++)
                    PointsArray[i, j] = new WorldPoint(WaterType._shallow_water, 0, null, null);
                for (int i = 1 + Globals.width_shallow_water; i <= Globals.width_coastal_water; i++)
                    PointsArray[i, j] = new WorldPoint(WaterType._coastal_water, 0, null, null);
                for (int i = 1 + Globals.width_coastal_water; i < Globals.world_x_size; i++)
                    PointsArray[i, j] = new WorldPoint(WaterType._dry, 0, null, null);
            }
            Creature.world = this;
        }

        public void add_new_cell(int _x, int _y, SingleCell _cell)
        {
            cells.Add(_cell);
            PointsArray[_x, _y].cell = _cell;
        }

        public void add_new_multi_cell(int _x, int _y, MultiCell _multi)
        {
            multi_cells.Add(_multi);
            PointsArray[_x, _y].multi_cell = _multi;
            PointsArray[_x+1, _y].multi_cell = _multi;
            PointsArray[_x, _y+1].multi_cell = _multi;
            PointsArray[_x+1, _y+1].multi_cell = _multi;
        }

        public void kill_cell(SingleCell _cell)
        {
            if (selected_cell == _cell)
                selected_cell = null;
            PointsArray[_cell.x, _cell.y].cell = null;
            if (!cells.Remove(_cell))
                Globals.soft_error("no cell to kill"); //error, no cell
            if (cells.Remove(_cell))
                Globals.soft_error("ghost cell to kill");   //error, double cell!
            return;
        }
        public void kill_multi_cell(MultiCell _multi)
        {
            if (selected_multicell == _multi)
                selected_multicell = null;
            PointsArray[_multi.x, _multi.y].multi_cell = null;
            PointsArray[_multi.x+1, _multi.y].multi_cell = null;
            PointsArray[_multi.x, _multi.y+1].multi_cell = null;
            PointsArray[_multi.x+1, _multi.y+1].multi_cell = null;
            if (!multi_cells.Remove(_multi))
                Globals.soft_error("no multicell to kill"); //error, no multicell
            if (multi_cells.Remove(_multi))
                Globals.soft_error("ghost multicell to kill");   //error, double multicell!
            return;
        }
        public void update_1day()
        {
            calendar++;
            for (int i = cells.Count - 1; i >= 0; i--)
                if (i < cells.Count)
                    cells[i].Update_1day();
            for (int i = multi_cells.Count - 1; i >= 0; i--)
                if (i < multi_cells.Count)
                    multi_cells[i].Update_1day();
            if (random_generator.Next(2) == 0)
                if (random_generator.Next(2) == 0)
                {   //low-tide
                    if (coast_line > Globals.width_shallow_water + 5)
                    {
                        coast_line--;
                        for (int i = 0; i < Globals.world_y_size; i++)
                            PointsArray[coast_line + 1, i].water = WaterType._dry;
                    }
                }
                else
                {   //high-tide
                    if (coast_line < Globals.world_x_size - 10 )
                    {
                        coast_line++;
                        for (int i = 0; i < Globals.world_y_size; i++)
                            PointsArray[coast_line, i].water = WaterType._coastal_water;
                    }
                }
                
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

        public void update_graphics(bool _show_cells)
        {
            graph.reset_world_view(coast_line);
            if(_show_cells)
                for (int i = cells.Count - 1; i >= 0; i--)
                    graph.draw_bmp(cells[i].face, cells[i].x, cells[i].y);
            for (int i = multi_cells.Count - 1; i >= 0; i--)
                graph.draw_bmp(multi_cells[i].face, multi_cells[i].x, multi_cells[i].y);
            graph.update_world_view();
        }

        public string get_point_info(int _x, int _y)
        {
            string result = "x: " + _x.ToString();
            result += "\r\ny: " + _y.ToString();
            result += "\r\norganics: " + PointsArray[_x, _y].organics.ToString();
            result += "\r\ncell: " + ((PointsArray[_x, _y].cell == null) ? "nobody" : PointsArray[_x, _y].cell.name.ToString());
            result += "\r\nmulti cell: " + ((PointsArray[_x, _y].multi_cell == null) ? "nobody" : PointsArray[_x, _y].multi_cell.name.ToString());
            return result;
        }
        public string get_world_info()
        {
            string result = "world age: " + calendar.ToString();
            result += "\r\ncells population: " + cells.Count.ToString();
            result += "\r\nmulti cells population: " + multi_cells.Count.ToString();
            return result;
        }

        public void wform_clicked(int _x, int _y)
        {
            if (PointsArray[_x, _y].multi_cell != null)
            {
                selected_multicell = PointsArray[_x, _y].multi_cell;
                selected_cell = null;
            }
            else
                if (PointsArray[_x, _y].cell != null)
                {
                    selected_cell = PointsArray[_x, _y].cell;
                    selected_multicell = null;
                }
        }
        public string get_creature_info()
        {
            string result = "";
            if (selected_multicell != null)
            {
                result = "multicell name: " + selected_multicell.name;
                result += "\r\n has: " + (selected_multicell.has_cholorophyl ? "cholorophyl " : " ") + (selected_multicell.has_mouth ? "mouth" : "");
                result += "\r\n has: " + (selected_multicell.has_fin ? "fin " : " ") + (selected_multicell.has_crawling_leg ? "crawling leg" : "");
                result += "\r\n is: " + (selected_multicell.has_genital_female ? "female " : " ") + (selected_multicell.has_genital_male ? "male" : "");
                result += "\r\n age: " + selected_multicell.age.ToString();
                result += "\r\n x: " + selected_multicell.x.ToString();
                result += "\r\n y: " + selected_multicell.y.ToString();
                result += "\r\n hump: " + selected_multicell.hump.ToString();
            }
            else if (selected_cell != null)
            {
                result = "cell name: " + selected_cell.name;
                result += "\r\n food: " + selected_cell.food_type.ToString();
                result += "\r\n age: " + selected_cell.age.ToString();
                result += " \\ " + selected_cell.age_max.ToString();
                result += "\r\n x: " + selected_cell.x.ToString();
                result += "\r\n y: " + selected_cell.y.ToString();
                result += "\r\n hump: " + selected_cell.hump.ToString();
                result += "\r\n breed at: " + selected_cell.breeding_thresh.ToString();
            }
            return result;
        }
    }
}
