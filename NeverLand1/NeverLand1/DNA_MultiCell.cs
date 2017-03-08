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
            DNA_MultiCell baby = DMA1;// new DNA_MultiCell();
            return baby;
        }
    }
}
