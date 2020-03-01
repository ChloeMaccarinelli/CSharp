using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_maccarinelli_fernandez
{

	class Program
	{
		static int count = 0;
		const int NBGENERATION = 10000;
		const int NBPOPULATION = 22;
		GestionnaireChemin gc = new GestionnaireChemin();

		public Program()
		{

		}

		public GestionnaireChemin initialiseChemins()
		{
			gc = new GestionnaireChemin();

			return gc;
		}

		public List<Ville> getVilles()
		{
			return this.gc.getVilles();
		}


		public static void linqTest()
		{
			GestionnaireChemin gc = new GestionnaireChemin();
			Chemin chemin = new Chemin(gc);

			Console.WriteLine("Evaluation du meilleur chemin, veuillez patienter ...");

			// Initialisation de la population
			Population pop = new Population(NBPOPULATION, gc);
			//Console.WriteLine("Distance initiale = " + pop.getMeilleurChemin().getDistance());

			// Evolution de la population sur 100 générations
			Algorithme ga = new Algorithme(gc);
			pop = ga.evoluerPopulation(pop);
			for (int i = 0; i < NBGENERATION; i++)
			{
				pop = ga.evoluerPopulation(pop);
				Console.WriteLine("Gen " + i + " : " + pop.getMeilleurChemin().getDistance());
			}

			Console.WriteLine("Distance finale = " + pop.getMeilleurChemin().getDistance());

			Chemin meilleurePopulation = pop.getMeilleurChemin();
		}
	}
}
