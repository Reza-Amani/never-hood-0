using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class World
    {
        WorldPoint[,] PointsArray = new WorldPoint[Globals.world_x_size, Globals.world_y_size];
        public List<SingleCell> cells = new List<SingleCell>();
        public World()
        {
            for (int i = 0; i < Globals.world_x_size; i++)
                for (int j = 0; j < Globals.world_y_size; j++)
                    PointsArray[i, j] = new WorldPoint(WaterType._coastal_water, 0, null);
        }

        public void update_1day()
        {
            for (int i = cells.Count - 1; i >= 0; i--)
            {
                if ( ! cells[i].Update_1day())
                {   //kill it
                    PointsArray[cells[i].x,cells[i].y].cell = null;
                    cells.RemoveAt(i);
                }
            }
        }
    }
}
