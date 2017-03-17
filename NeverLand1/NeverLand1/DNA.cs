using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class DNA
    {
        List<Gene> genume = new List<Gene>();
        Gene gene2, gene1, new_gene;
        DNA()
        {
        }
        DNA(DNA DNA1,DNA DNA2)
        {
            foreach(Gene gene1 in DNA1.genume)
            {
                gene2 = DNA2.genume.Find(g => g.name == gene1.name);
                if (gene2 == default(Gene))
                {   //gene1 has no twin in DNA2
                    if (Globals.get_random_bool())
                    {   //give the single gene to the baby 
                        new_gene = new Gene(gene1);
                        genume.Add(new_gene);
                    }//else: not lucky gene, drop it
                }
                else
                {   //A pair gene is found in DNA2
                    new_gene = new Gene(gene1,gene2);
                    genume.Add(new_gene);
                }
            }
            foreach (Gene gene2 in DNA2.genume)
            {
                gene1 = DNA1.genume.Find(g => g.name == gene2.name);
                if (gene1 == default(Gene))
                {   //a gene in DNA2 that is not found in DNA1
                    if (Globals.get_random_bool())
                    {   //give the single gene to the baby 
                        new_gene = new Gene(gene2);
                        genume.Add(new_gene);
                    }   //else: a common gene has been taken into account; no need to consider it again
                }
            }
        }
 /*       static DNA pairing()
        {
            DNA baby = new DNA(
                Globals.get_random_bool() ? DNA1.mouth : DNA2.mouth,
                Globals.get_random_bool() ? DNA1.cholorophyl : DNA2.cholorophyl,
                Globals.get_random_bool() ? DNA1.genital_male : DNA2.genital_male,
                Globals.get_random_bool() ? DNA1.genital_female : DNA2.genital_female,
                Globals.get_random_bool() ? DNA1.fin : DNA2.fin,
                Globals.get_random_bool() ? DNA1.crawling_leg : DNA2.crawling_leg,
                Globals.get_random_int_inc(DNA1.max_age, DNA2.max_age),
                Globals.get_random_int_inc(DNA1.embryo_hump, DNA2.embryo_hump),
                Globals.get_random_int_inc(DNA1.reproduction_interval, DNA2.reproduction_interval)
                );
            return baby;
        }
        */
        //use it to find genes: MyClass result = list.Find(x => x.GetId() == "xy");
        //not in single cells
    }
}
