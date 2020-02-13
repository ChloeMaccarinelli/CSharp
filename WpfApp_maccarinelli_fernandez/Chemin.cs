using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp_maccarinelli_fernandez
{
    public class Chemin
    {
        GestionnaireChemin gc;
        List<Ville> chemin;
        Double score;
        Double distance;

        public Chemin(GestionnaireChemin gc)
        {
            this.gc = gc;
            this.chemin = gc.getVilles();
            this.score = 0.0;
            this.distance = 0.0;
        }

        public int tailleChemin()
        {
            return chemin.Count;
        }

        public void setVille(int indexCircuit, Ville ville)
        {
            chemin[indexCircuit] = ville;
            this.score = 0.0;
            this.distance = 0.0;
        }

        public Ville getVilleInChemin(int index)
        {
            return this.chemin[index];
        }

        public double getScore()
        {
            return this.score;
        }

        public double getDistance()
        {
            Double distanceTotal = new double();

            for (int i = 0; i < this.chemin.Count - 1; i++)
            {
                Ville v1 = this.chemin[i];
                Ville v2 = this.chemin[i + 1];


                distanceTotal += (Double)v1.distance(v1, v2);
            }
            this.score = distanceTotal;
            return distanceTotal;
        }

        public void genererIndividu()
        {
            foreach (int indiceVille in Enumerable.Range(0, gc.nombreDeVilles()))
            {
                chemin.Add(gc.getVille(indiceVille));
            }
        }

        public bool contientVille(Ville villeACheck)
        {
            for (int i = 0; i < this.chemin.Count; i++)
            {
                if (villeACheck == this.chemin[i])
                {
                    return true;
                }
            }

            return false;
        }

    }
}
