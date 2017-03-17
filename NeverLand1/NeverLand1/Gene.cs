using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class Gene
    {
        public enum GeneType
        {
            _mouth, _cholorophyl, _genital_male, _genital_female, _fin, _crawling_leg
        }
        public int value { get; set; }
        public int absolute_min { get; set; }
        public int absolute_max { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public GeneType name { get; set; }
    }

}
