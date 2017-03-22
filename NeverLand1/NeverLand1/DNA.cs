using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    class DNA
    {
        List<Gene> genume = new List<Gene>();
        DNA()
        {
        }
        DNA(DNA DNA1,DNA DNA2)
        {
            Gene gene2, gene1, new_gene; 
            foreach (Gene _gene1 in DNA1.genume)
            {
                gene2 = DNA2.genume.Find(g => g.name == _gene1.name);
                if (gene2 == default(Gene))
                {   //gene1 has no twin in DNA2
                    if (Globals.get_random_bool())
                    {   //give the single gene to the baby 
                        new_gene = new Gene(_gene1);
                        genume.Add(new_gene);
                    }//else: not lucky gene, drop it
                }
                else
                {   //A pair gene is found in DNA2
                    new_gene = new Gene(_gene1,gene2);
                    genume.Add(new_gene);
                }
            }
            foreach (Gene _gene2 in DNA2.genume)
            {

                gene1 = DNA1.genume.Find(g => g.name == _gene2.name);
                if (gene1 == default(Gene))
                {   //a gene in DNA2 that is not found in DNA1
                    if (Globals.get_random_bool())
                    {   //give the single gene to the baby 
                        new_gene = new Gene(_gene2);
                        genume.Add(new_gene);
                    }   //else: a common gene has been taken into account; no need to consider it again
                }
            }
        }
        DNA(SingleCell _cell)
        {
            if(_cell.food_type == FoodType._sun_light)
                genume.Add(new Gene(Gene.GeneType._cholorophyl, 1, 0, 1));
            if(_cell.food_type == FoodType._single_cell)
                genume.Add(new Gene(Gene.GeneType._mouth, 1, 0, 1));
        }
    }
}
