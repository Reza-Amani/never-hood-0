using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class DNA_MultiCell
    {
        public bool mouth, cholorophyl, genital_male, genital_female, fin, crawling_leg;
        public int max_age, embryo_hump;
        DNA_MultiCell(bool _mouth, bool _cholorophyl, bool _genital_male, bool _genital_female, bool _fin, bool _crawling_leg, int _max_age, int _embryo_hump)
        {
            mouth = _mouth; cholorophyl = _cholorophyl; genital_male = _genital_male; genital_female = _genital_female; fin = _fin; crawling_leg = _crawling_leg; max_age = _max_age; embryo_hump = _embryo_hump;
        }
        static DNA_MultiCell pairing(DNA_MultiCell DMA1, DNA_MultiCell DMA2)
        {
            DNA_MultiCell baby = new DNA_MultiCell(
                Globals.get_random_bool()?DMA1.mouth:DMA2.mouth,
                Globals.get_random_bool()?DMA1.cholorophyl:DMA2.cholorophyl,
                Globals.get_random_bool()?DMA1.genital_male:DMA2.genital_male,
                Globals.get_random_bool()?DMA1.genital_female:DMA2.genital_female,
                Globals.get_random_bool()?DMA1.fin:DMA2.fin,
                Globals.get_random_bool()?DMA1.crawling_leg:DMA2.crawling_leg,
                Globals.get_random_int_inc(DMA1.max_age,DMA2.max_age),
                Globals.get_random_int_inc(DMA1.embryo_hump,DMA2.embryo_hump)
                );
            return baby;
        }
    }
}
