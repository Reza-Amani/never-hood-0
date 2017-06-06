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
            _mouth, _cholorophyl, _genital_male, _genital_female, _fin, _crawling_leg, _ft_max_age, _ft_embryo_hump, _ft_reproduction_interval
        }
        public static int  genetype_size=6;
        public Gene(GeneType _name, int _value, int _min, int _max)
        {   //initial constructor
            if (_value > _max)
                _value = _max;
            if (_value < _min)
                _value = _min;
            value = _value;
            min = _min;
            max = _max;
            name = _name;
        }
        public Gene(Gene _gene)
        {   //copy constructor
            value = _gene.value;
            min = _gene.min;
            max = _gene.max;
            name = _gene.name;
        }
        public Gene(Gene _gene1, Gene _gene2)
        {   //mutation constructor
            if (_gene1.name != _gene2.name)
                Globals.soft_error("pairing different-type genes");
            name = _gene1.name;
            value = Globals.get_random_int_inc(_gene1.value, _gene2.value);
            min = Globals.get_random_int_inc(_gene1.min, _gene2.min);
            max = Globals.get_random_int_inc(_gene1.max, _gene2.max);
        }
        public void mutate()
        {
            value = Globals.get_random_int_inc(min, max);
        }
        public int value { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public GeneType name { get; set; }
    }

}
