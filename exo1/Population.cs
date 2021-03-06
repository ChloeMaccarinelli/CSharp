﻿using System;
using System.Collections.Generic;
using System.Text;

namespace exo1
{
    public class Population
    {
        GestionnaireChemin gc;
        List<Chemin> lesCheminsRetenus;
        int taillePopulation;

        public Population(int taillePopulation, GestionnaireChemin gc)
        {
            this.gc = gc;
            this.lesCheminsRetenus = new List<Chemin>();
            for(int i = 0; i < taillePopulation; i++)
            {
                this.lesCheminsRetenus.Add(new Chemin(gc));
            }
            this.taillePopulation = taillePopulation;
        }

        public void sauvegarderCircuit(Chemin cheminASauvegarder)
        {
            this.lesCheminsRetenus.Add(cheminASauvegarder);
        }

        public Chemin getChemin(int index)
        {
            try
            {
                return this.lesCheminsRetenus[index];
            } catch (Exception e)
            {
                Console.WriteLine("Erreur dans la récupération d'un chemin dans la population !");
            }

            return null;
        }

        public int getTaillePopulation()
        {
            return this.taillePopulation;
        }

        public Chemin getMeilleurChemin()
        {
            try
            {
                Chemin meilleurCheminARenvoyer = this.lesCheminsRetenus[0];

                for (int i = 1; i < this.lesCheminsRetenus.Count; i++)
                {
                    if (meilleurCheminARenvoyer.getDistance() >
                        this.lesCheminsRetenus[i].getDistance())
                    {
                        meilleurCheminARenvoyer = this.lesCheminsRetenus[i];
                    }
                }
                return meilleurCheminARenvoyer;
            } catch(Exception e)
            {
                Console.WriteLine("Erreur dans le meilleur chemin a renvoyer !");
            }

            return null;
        }


    }
}
