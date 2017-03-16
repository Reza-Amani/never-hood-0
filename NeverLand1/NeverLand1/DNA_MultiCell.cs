using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class DNA_MultiCell
    {
        public bool mouth, cholorophyl, genital_male, genital_female, fin, crawling_leg;
        public int max_age, embryo_hump, reproduction_interval;
        DNA_MultiCell(bool _mouth, bool _cholorophyl, bool _genital_male, bool _genital_female, bool _fin, bool _crawling_leg, int _max_age, int _embryo_hump, int _reproduction_interval)
        {
            mouth = _mouth; cholorophyl = _cholorophyl; genital_male = _genital_male; genital_female = _genital_female; fin = _fin; crawling_leg = _crawling_leg; max_age = _max_age; embryo_hump = _embryo_hump; reproduction_interval = _reproduction_interval;
        }
        static DNA_MultiCell pairing(DNA_MultiCell DNA1, DNA_MultiCell DNA2)
        {
            DNA_MultiCell baby = new DNA_MultiCell(
                Globals.get_random_bool()?DNA1.mouth:DNA2.mouth,
                Globals.get_random_bool()?DNA1.cholorophyl:DNA2.cholorophyl,
                Globals.get_random_bool()?DNA1.genital_male:DNA2.genital_male,
                Globals.get_random_bool()?DNA1.genital_female:DNA2.genital_female,
                Globals.get_random_bool()?DNA1.fin:DNA2.fin,
                Globals.get_random_bool()?DNA1.crawling_leg:DNA2.crawling_leg,
                Globals.get_random_int_inc(DNA1.max_age,DNA2.max_age),
                Globals.get_random_int_inc(DNA1.embryo_hump,DNA2.embryo_hump),
                Globals.get_random_int_inc(DNA1.reproduction_interval,DNA2.reproduction_interval)
                );
            return baby;
        }
        static DNA_MultiCell build_from_single_cell(SingleCell parent)
        {
            bool gender=Globals.get_random_bool();
            DNA_MultiCell baby = new DNA_MultiCell(
                (parent.food_type == FoodType._single_cell) ? true : false,
                (parent.food_type == FoodType._sun_light) ? true : false,
                gender,
                !gender,
                false,
                false,
                parent.age_max * 5,
                parent.breeding_thresh / 2,
                50
                );
            return baby;
        }
        bool check_mutation()
        {
            if (Globals.get_random_int_inc(0, 100) != 0)
                return false;
            switch (Globals.get_random_int_inc(0, 9))
            {
                case 0: mouth = !mouth; break;
                case 1: cholorophyl = !cholorophyl; break;
                case 2: genital_male = !genital_male; break;
                case 3: genital_female = !genital_female; break;
                case 4: fin = !fin; break;
                case 5: crawling_leg = !crawling_leg; break;
                case 8: max_age = Globals.mutate(max_age, 10, 10, MultiCell.absolute_max_age, 10); break;
                case 9: reproduction_interval = Globals.mutate(reproduction_interval, 10, 10, 1000, 20); break;
            }
            return true;
        }
    }
}
