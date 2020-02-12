using System;
using System.Collections.Generic;
using System.Text;

namespace exo1
{
    public class Algorithme
    {
        double tauxMutation;
        int tailleTournoi;
        GestionnaireChemin gc;
        bool elitisme;

        public Algorithme(GestionnaireChemin gc)
        {
            this.tauxMutation = 0.015;
            this.tailleTournoi = 5;
            this.elitisme = true;
            this.gc = gc;
        }

        public Population evoluerPopulation(Population pop)
        {
            Population nouvellePopulation = new Population(pop.getTaillePopulation(), gc);
            int elitismeOffset = 0;

            if (this.elitisme)
            {
                nouvellePopulation.sauvegarderCircuit(pop.getMeilleurChemin());
                elitismeOffset = 1;
            }

            // On effectue le tournoi
            for(int i = elitismeOffset; i < nouvellePopulation.getTaillePopulation(); i++)
            {
                Chemin parent1 = selectionTournoi(pop);
                Chemin parent2 = selectionTournoi(pop);
                Chemin enfant = crossover(parent1, parent2);
                nouvellePopulation.sauvegarderCircuit(enfant);
            }

            // On fait muter les nouveux éléments !
            for (int i = elitismeOffset; i < nouvellePopulation.getTaillePopulation(); i++)
            {
                this.muter(nouvellePopulation.getChemin(i));
            }

            return nouvellePopulation;
        }

        public Chemin crossover(Chemin parent1, Chemin parent2)
        {
            Chemin enfant = new Chemin(this.gc);

            Random rand = new Random();

            int positionStart = (int)(rand.NextDouble() * parent1.tailleChemin());
            int positionEnd = (int)(rand.NextDouble() * parent1.tailleChemin());

            // On voit si on ajoute le parent 1
            for(int i = 0; i < enfant.tailleChemin(); i++)
            {
                // On set la ville de l'enfant par le parent
                if(positionStart < positionEnd &&
                    i > positionStart &&
                    i < positionEnd)
                {
                    enfant.setVille(i, parent1.getVilleInChemin(i));
                } else if(positionStart > positionEnd) {
                    if(!(i < positionStart && i > positionEnd))
                    {
                        enfant.setVille(i, parent1.getVilleInChemin(i));
                    }
                }
            }

            for(int i = 0; i < parent2.tailleChemin(); i++)
            {
                if (!(enfant.contientVille(parent2.getVilleInChemin(i))))
                {
                    for(int j = 0; i < enfant.tailleChemin(); i++) {
                        if(enfant.getVilleInChemin(j) == null)
                        {
                            enfant.setVille(j, parent2.getVilleInChemin(j));
                        }
                    }
                }
            }
            return enfant;
        }

        public void muter(Chemin cheminAMuter)
        {
            Random rand = new Random();

            for(int i = 0; i < cheminAMuter.tailleChemin(); i++)
            {
                if (rand.NextDouble() < tauxMutation)
                {
                    double j = cheminAMuter.tailleChemin() * rand.NextDouble();

                    Ville ville1 = cheminAMuter.getVilleInChemin((int)i);
                    Ville ville2 = cheminAMuter.getVilleInChemin((int)j);

                    cheminAMuter.setVille((int)j, ville1);
                    cheminAMuter.setVille(i, ville2);
                }
            }
        }

        public Chemin selectionTournoi(Population pop)
        {
            Population tournoi = new Population(this.tailleTournoi, this.gc);
            Random rand = new Random();
            Chemin meilleurChemin;

            for(int i = 0; i < this.tailleTournoi; i++)
            {
                int randomId = (int)(rand.NextDouble() * pop.getTaillePopulation());
                tournoi.sauvegarderCircuit(pop.getChemin(randomId));
            }

            meilleurChemin = tournoi.getMeilleurChemin();

            return meilleurChemin;
        }
    }
}
