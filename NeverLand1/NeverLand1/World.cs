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
        public World(graphic _g,Random _rnd)
        {
            for (int i = 0; i < Globals.world_x_size; i++)
                for (int j = 0; j < Globals.world_y_size; j++)
                    PointsArray[i, j] = new WorldPoint(WaterType._coastal_water, 0, null);
            graph = _g;
            random_generator = _rnd;
        }

        public void update_1day()
        {
            for (int i = cells.Count - 1; i >= 0; i--)
                cells[i].Update_1day();
            for (int i = cells.Count - 1; i >= 0; i--)
                if (cells[i].to_dye)
                    cells.RemoveAt(i);
            graph.reset_world_view();
            for (int i = cells.Count - 1; i >= 0; i--)
                graph.draw_bmp(cells[i].face, cells[i].x, cells[i].y);
            graph.update_world_view();
        }
    }
}
