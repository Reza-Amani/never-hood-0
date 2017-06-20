using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverLand1
{
    [Serializable]
    class DNA
    {
        public List<Gene> genume = new List<Gene>();
        public List<Gene> par_genume = new List<Gene>();
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
            foreach (Gene _gene2 in DNA2.par_genume)
            {
                gene1 = DNA1.par_genume.Find(g => g.name == _gene2.name);
                if (gene1 == default(Gene))
                    Globals.soft_error("missing gene in pargenume");
                else
                {
                    new_gene = new Gene(gene1, _gene2);
                    genume.Add(new_gene);
                }
            }
        }
        public DNA(SingleCell _cell)
        {
            if(_cell.food_type == FoodType._sun_light)
                genume.Add(new Gene(Gene.GeneType._cholorophyl, 1, 0, 1));
            if(_cell.food_type == FoodType._single_cell)
                genume.Add(new Gene(Gene.GeneType._mouth, 1, 0, 1));
            par_genume.Add(new Gene(Gene.GeneType._ft_max_age, _cell.age_max, 100, 10000));
            par_genume.Add(new Gene(Gene.GeneType._ft_reproduction_interval, _cell.breeding_thresh, 100, 1000));
            par_genume.Add(new Gene(Gene.GeneType._ft_embryo_hump, 50, 100, 1000));
        }
        public bool check_mutation()
        {
            switch (Globals.get_random_int_inc(0, 100))
            {
                case 0: //mutation on one of existing genes
                    if (Globals.get_random_bool())
                    {
                        if (genume.Count > 0)
                            genume[Globals.get_random_int_inc(0, genume.Count - 1)].mutate();
                    }
                    else
                    {
                        if (par_genume.Count > 0)
                            par_genume[Globals.get_random_int_inc(0, par_genume.Count - 1)].mutate();
                    }
                    break;
                case 2:     //deleting one of the existing genes
                    if (genume.Count > 0)
                        genume.RemoveAt(Globals.get_random_int_inc(0, genume.Count - 1));
                    break;
                case 1:     //adding a new gene (only genes can be added, not pargenes)
                    Gene temp_gene;
                    switch(Globals.get_random_int_inc(0,Gene.genetype_size-1))
                    {
                        case 0:
                            temp_gene = genume.Find(g => g.name == Gene.GeneType._cholorophyl);
                            if (temp_gene == default(Gene))     //this is a new gene; it can't be found in the existing genume
                                genume.Add(new Gene(Gene.GeneType._cholorophyl, 1, 0, 1));
                            break;
                        case 1:
                            temp_gene = genume.Find(g => g.name == Gene.GeneType._crawling_leg);
                            if (temp_gene == default(Gene))     //this is a new gene; it can't be found in the existing genume
                                genume.Add(new Gene(Gene.GeneType._crawling_leg, 1, 0, 1));
                            break;
                        case 2:
                            temp_gene = genume.Find(g => g.name == Gene.GeneType._fin);
                            if (temp_gene == default(Gene))     //this is a new gene; it can't be found in the existing genume
                                genume.Add(new Gene(Gene.GeneType._fin,1,0,1));
                            break;
                        case 3:
                            temp_gene = genume.Find(g => g.name == Gene.GeneType._genital_female);
                            if (temp_gene == default(Gene))     //this is a new gene; it can't be found in the existing genume
                                genume.Add(new Gene(Gene.GeneType._genital_female,1,0,1));
                            break;
                        case 4:
                            temp_gene = genume.Find(g => g.name == Gene.GeneType._genital_male);
                            if (temp_gene == default(Gene))     //this is a new gene; it can't be found in the existing genume
                                genume.Add(new Gene(Gene.GeneType._genital_male,1,0,1));
                            break;
                        case 5:
                            temp_gene = genume.Find(g => g.name == Gene.GeneType._mouth);
                            if (temp_gene == default(Gene))     //this is a new gene; it can't be found in the existing genume
                                genume.Add(new Gene(Gene.GeneType._mouth,1,0,1));
                            break;
                    }
                   
                    break;
                default:    //not this time
                    return false;
            }
            return true;
        }
    }
}
