using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NeverLand1
{
    [Serializable]
    class MultiCell : Creature
    {
        DNA DNA;
        public MultiCell(int _x, int _y, DNA _DNA, int _age, int _hump, int _name)
        {
            x = _x; y = _y; DNA = _DNA; age = _age; hump = _hump;
            size = 2;
            face = new Bitmap(size, size);
            to_dye = false;
            name = _name;
            update_organs_from_genume();
            update_parameters_from_pargenume();
            update_face();
            do_move(_x, _y);
        }
        public int days_from_last_reproduction=0;
        public const int absolute_max_age = 1000;
        public bool has_cholorophyl, has_mouth, has_genital_male, has_genital_female, has_fin, has_crawling_leg;
        public int par_max_age, par_embryo_hump, par_reproduction_interval;

        override protected void update_organs_from_genume()
        {
            Gene temp_gene = DNA.genume.Find(g => g.name == Gene.GeneType._cholorophyl);
            has_cholorophyl = false;
            if (temp_gene != default(Gene))
                if (temp_gene.value == 1)
                    has_cholorophyl = true;
            temp_gene = DNA.genume.Find(g => g.name == Gene.GeneType._mouth);
            has_mouth = false;
            if (temp_gene != default(Gene))
                if (temp_gene.value == 1)
                    has_mouth = true;
            temp_gene = DNA.genume.Find(g => g.name == Gene.GeneType._genital_male);
            has_genital_male = false;
            if (temp_gene != default(Gene))
                if (temp_gene.value == 1)
                    has_genital_male = true;
            temp_gene = DNA.genume.Find(g => g.name == Gene.GeneType._genital_female);
            has_genital_female = false;
            if (temp_gene != default(Gene))
                if (temp_gene.value == 1)
                    has_genital_female = true;
            temp_gene = DNA.genume.Find(g => g.name == Gene.GeneType._fin);
            has_fin = false;
            if (temp_gene != default(Gene))
                if (temp_gene.value == 1)
                    has_fin = true;
            temp_gene = DNA.genume.Find(g => g.name == Gene.GeneType._crawling_leg);
            has_crawling_leg = false;
            if (temp_gene != default(Gene))
                if (temp_gene.value == 1)
                    has_crawling_leg = true;
        }

        override protected void update_parameters_from_pargenume()
        {
            Gene temp_gene = DNA.par_genume.Find(g => g.name == Gene.GeneType._ft_max_age);
            if (temp_gene != default(Gene))
                par_max_age = temp_gene.value;
            else
                par_max_age = 100;
            temp_gene = DNA.par_genume.Find(g => g.name == Gene.GeneType._ft_embryo_hump);
            if (temp_gene != default(Gene))
                par_embryo_hump = temp_gene.value;
            else
                par_embryo_hump = 10;
            temp_gene = DNA.par_genume.Find(g => g.name == Gene.GeneType._ft_reproduction_interval);
            if (temp_gene != default(Gene))
                par_reproduction_interval = temp_gene.value;
            else
                par_reproduction_interval = Globals.default_multi_reproduction_interval_min;
        }

        override protected void update_face()
        {
            if (has_cholorophyl && has_mouth)
                face.SetPixel(0, 0, Color.Yellow);
            else if (has_cholorophyl)
                face.SetPixel(0, 0, Color.Green);
            else if (has_mouth)
                face.SetPixel(0, 0, Color.Red);
            else if (!has_mouth && !has_cholorophyl)
                face.SetPixel(0, 0, Color.White);

            if (has_crawling_leg)
                face.SetPixel(0, 1, Color.Black);
            else
                face.SetPixel(0, 1, Color.Gray);

            if (has_fin)
                face.SetPixel(1, 0, Color.DarkBlue);
            else
                face.SetPixel(1, 0, Color.Gray);

            if (has_genital_female && has_genital_male)
                face.SetPixel(1, 1, Color.Violet);
            else if (has_genital_female)
                face.SetPixel(1, 1, Color.Pink);
            else if (has_genital_male)
                face.SetPixel(1, 1, Color.Brown);
            else if (!has_genital_female && !has_genital_male)
                face.SetPixel(1, 1, Color.Gray);

        }
        override protected void choose_next_pixel(int _x, int _y, out int _new_x, out int _new_y)
        {
            int newx, newy;
            if( (has_crawling_leg && world.PointsArray[_x, _y].water == WaterType._dry) ||
                (has_fin && world.PointsArray[_x, _y].water != WaterType._dry) )
            {
                newx = _x + Globals.get_random_int_inc(-2,2);
                newy = _y + Globals.get_random_int_inc(-2, 2);
            }
            else
            {
                newx = _x + Globals.get_random_int_inc(-1, 1);
                newy = _y + Globals.get_random_int_inc(-1, 1);
            }
            if ((newx < Globals.world_x_size -size+1) && (newx >= 0) && (newy < Globals.world_y_size -size+1) && (newy >= 0))
            {   //propose new point 
                _new_x = newx;
                _new_y = newy;
            }
            else
            {   //new point out of border, stay still
                _new_x = _x;
                _new_y = _y;
            }
        }

        override protected void reproduce(ref int _new_x, ref int _new_y)
        {   //TODO:
            if(has_genital_female && has_genital_male)
                if ( ! is_there_another_multi(_new_x, _new_y))
                    if (hump > 2*par_embryo_hump)
                    {
                        hump -= par_embryo_hump;
                        MultiCell _new_born = new MultiCell(_new_x, _new_y, DNA, 0, par_embryo_hump, world.multi_ID++);
                        world.add_new_multi(_new_x, _new_y, _new_born);
                        _new_x = x;
                        _new_y = y;
                    }
        }
        override protected void move_eat(int _new_x, int _new_y)
        {
            if(is_there_another_multi(_new_x, _new_y))
            {   //the destination is occupied by another multicell, don't move
                _new_x = x;
                _new_y = y;
            }
            do_move(_new_x, _new_y);
            if(has_cholorophyl)
                hump += 4*world.PointsArray[x, y].get_sun_energy();
            if(has_mouth)
            {//eat single cells under
                SingleCell cell;
                cell = world.PointsArray[x, y].cell;
                if (cell != null)
                    eat_cell(cell);
                cell = world.PointsArray[x+1, y].cell;
                if (cell != null)
                    eat_cell(cell);
                cell = world.PointsArray[x, y+1].cell;
                if (cell != null)
                    eat_cell(cell);
                cell = world.PointsArray[x+1, y+1].cell;
                if (cell != null)
                    eat_cell(cell);
            }

        }
        bool is_there_another_multi(int _x, int _y)
        { //returns true if somebody else is there
            if (world.PointsArray[_x + 0, _y + 0].multi_cell != null && world.PointsArray[_x + 0, _y + 0].multi_cell != this)
                return true;
            if (world.PointsArray[_x + 1, _y + 0].multi_cell != null && world.PointsArray[_x + 1, _y + 0].multi_cell != this)
                return true;
            if (world.PointsArray[_x + 0, _y + 1].multi_cell != null && world.PointsArray[_x + 0, _y + 1].multi_cell != this)
                return true;
            if (world.PointsArray[_x + 1, _y + 1].multi_cell != null && world.PointsArray[_x + 1, _y + 1].multi_cell != this)
                return true;
            return false;
        }
        void eat_cell(SingleCell _cell)
        {
            hump += _cell.hump;
            world.PointsArray[_cell.x, _cell.y].cell = null;
            _cell.to_dye = true;
            _cell.hump = 0;
        }
        void do_move(int _newx, int _newy)
        {
            world.PointsArray[x, y].multi_cell = null;
            world.PointsArray[x+1, y].multi_cell = null;
            world.PointsArray[x, y+1].multi_cell = null;
            world.PointsArray[x+1, y+1].multi_cell = null;
            world.PointsArray[_newx, _newy].multi_cell = this;
            world.PointsArray[_newx+1, _newy].multi_cell = this;
            world.PointsArray[_newx, _newy+1].multi_cell = this;
            world.PointsArray[_newx+1, _newy+1].multi_cell = this;
            x = _newx;
            y = _newy;
        }
        override protected void metabolism()
        {
            int consumption = 4;
            if (has_cholorophyl)
                consumption += 2;
            if (has_crawling_leg)
                consumption += 2;
            if (has_fin)
                consumption += 2;
            if (has_genital_female)
                consumption += 2;
            if (has_genital_male)
                consumption += 2;
            if (has_mouth)
                consumption += 2;

            if (consumption > hump) //not enough enough stored energy
                consumption = hump;

            hump -= consumption;
            world.PointsArray[x, y].organics += consumption;

            if (age > par_max_age || hump==0)
            {   //checking age_max
                world.PointsArray[x, y].organics += hump;
                hump = 0;
                to_dye = true;
                return;
            }
        }
        override protected void mutation()
        {
            if (DNA.check_mutation())
            {
                update_organs_from_genume();
                update_parameters_from_pargenume();
                update_face();
            }
        }
    }
}
