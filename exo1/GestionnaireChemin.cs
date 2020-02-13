using System;
using System.Collections.Generic;
using System.Text;

namespace exo1
{
    public class GestionnaireChemin
    {
        List<Ville> villesInChemin;
        Population populationActuelle;

        public GestionnaireChemin(List<Ville> lesVilles) {
            this.villesInChemin = lesVilles;
        }
        public GestionnaireChemin()
        {
            this.villesInChemin = new List<Ville>();

           this.villesInChemin.Add(new Ville(3.002556, 45.846117, "Clermont-Ferrand"));
           this.villesInChemin.Add(new Ville(-0.644905, 44.896839, "Bordeaux"));
           this.villesInChemin.Add(new Ville(-1.380989, 43.470961, "Bayonne"));
           this.villesInChemin.Add(new Ville(1.376579, 43.662010, "Toulouse"));
           this.villesInChemin.Add(new Ville(5.337151, 43.327276, "Marseille"));
           this.villesInChemin.Add(new Ville(7.265252, 43.745404, "Nice"));
           this.villesInChemin.Add(new Ville(-1.650154, 47.385427, "Nantes"));
           this.villesInChemin.Add(new Ville(-1.430427, 48.197310, "Rennes"));
           this.villesInChemin.Add(new Ville(2.414787, 48.953260, "Paris"));
           this.villesInChemin.Add(new Ville(3.090447, 50.612962, "Lille"));
           this.villesInChemin.Add(new Ville(5.013054, 47.370547, "Dijon"));
           this.villesInChemin.Add(new Ville(4.793327, 44.990153, "Valence"));
           this.villesInChemin.Add(new Ville(2.447746, 44.966838, "Aurillac"));
           this.villesInChemin.Add(new Ville(1.750115, 47.980822, "Orleans"));
           this.villesInChemin.Add(new Ville(4.134148, 49.323421, "Reims"));
           this.villesInChemin.Add(new Ville(7.506950, 48.580332, "Strasbourg"));
           this.villesInChemin.Add(new Ville(1.233757, 45.865246, "Limoges"));
           this.villesInChemin.Add(new Ville(4.047255, 48.370925, "Troyes"));
           this.villesInChemin.Add(new Ville(0.103163, 49.532415, "Le Havre"));
           this.villesInChemin.Add(new Ville(-1.495348, 49.667704, "Cherbourg"));
           this.villesInChemin.Add(new Ville(-4.494615, 48.447500, "Brest"));
           this.villesInChemin.Add(new Ville(-0.457140, 46.373545, "Niort"));
        }

        public List<Ville> getVilles()
        {
            return this.villesInChemin;
        }

        public Ville getVille(int index)
        {
            return (Ville)this.villesInChemin[index];
        }

        public void setVilles(List<Ville> nouvellesVilles)
        {
            this.villesInChemin = nouvellesVilles;
        }

        public int nombreDeVilles()
        {
            return this.villesInChemin.Count;
        }
    }
}
