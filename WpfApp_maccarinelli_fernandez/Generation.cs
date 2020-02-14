using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_maccarinelli_fernandez
{
    public class Generation
    {
        public int numberGeneration { get; set; }
        public double moyenne { get; set; }
        public double plusPetit { get; set; }

        public Generation()
        {
            this.numberGeneration = 0;
            this.moyenne = 0;
            this.plusPetit = 0;
        }

        public Generation(int numberGeneration, double moyenne, double plusPetit)
        {
            this.numberGeneration = numberGeneration;
            this.moyenne = moyenne;
            this.plusPetit = plusPetit;
        }
    }
}
