using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo1
{

	class Program
	{
		static int count = 0;
		const int NBGENERATION = 100;
		const int NBPOPULATION = 22;

		static void Main(string[] args)
		{
			linqTest();
		}

		public Program()
		{

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
			for(int i = 0; i < NBGENERATION; i++)
			{
				pop = ga.evoluerPopulation(pop);
				Console.WriteLine("Gen " + i + " : " + pop.getMeilleurChemin().getDistance());
			}

			Console.WriteLine("Distance finale = " + pop.getMeilleurChemin().getDistance());

			Chemin meilleurePopulation = pop.getMeilleurChemin();
		}
	}
}
















































		/**
		 * Génère des villes à une position aléatoire
		 
		public static Dictionary<int, Ville> genererVilles(int nbVilles)
		{
			Dictionary<int, Ville> list = new Dictionary<int, Ville>();

			for(int i = 0; i < nbVilles; i++)
			{
				var random = new Random();
				var byt = new byte[4];
				random.NextBytes(byt);
				list.Add(count, new Ville("test", 'Z', (float)random.Next(), (float)random.Next()));
				count++;
			}

			return list;
		}

		/**
		 * Mélange les villes pour en faire un chemin aléatoire
		 
		public static List<Chemin> shuffleVilles(Dictionary<int, Ville> lesVilles)
		{
			List<Chemin> shuffledChemin = new List<Chemin>();
			int i = 0;

			while(i < lesVilles.Count) {
				shuffledChemin.Add(new Chemin(genererVilles(10)));
				i++;
			}

			return shuffledChemin;
		}

		/**
		 * Boucle principale pour les tests
		 * 
		 
		public static void linqTest()
		{
			Dictionary<int, Ville> listVille = new Dictionary<int, Ville>();


			listVille = genererVilles(10);

			// Creation de tous les chemins 
			List<Chemin> lesChemins = new List<Chemin>();

			lesChemins = shuffleVilles(listVille);

			// Récupération des 10 meilleurs chemins
			IEnumerable<List<Chemin>> getDixMeilleursChemins =
				from chemin in lesChemins
				select dixMeilleursChemins(lesChemins);

			// Récupération de tous les chemins pour affichage
			IEnumerable<string> getAllChemins =
				from chemin in lesChemins
				where chemin.ToString() == chemin.ToString()
				select chemin.montrerLettreVille();

			// Creation de la querry
			IEnumerable<string> lettreQuerry =
				from ville in listVille.Values
				where (ville.getLettre()) == 'A'
				select ville.nom;

			// Creation de la querry
			IEnumerable<string> getAllQuerry =
				from ville in listVille.Values
				where ville.nom == ville.nom
				select ville.nom;

			// Prendre que les villes qui commencent par A ou a
			IEnumerable<string> getVilleWithA =
				from ville in listVille.Values
				where ville.nom.ToLower()[0] == 'a'
				select ville.nom;

			// Prendre que les villes qui commencent par A ou a
			IEnumerable<string> getVilleWithDistanceEnDessousMoyenne =
				from ville in listVille.Values
				where ville.nom.ToLower()[0] == 'a'
				select ville.nom;

			foreach (string nom in getAllChemins)
			{
				Console.WriteLine("Un chemin : " + nom);
			}

			List<Chemin> lesDixMeilleursChemins = getDixMeilleursChemins.First();

			for (int i = 0; i < lesDixMeilleursChemins.Count(); i++)
			{
				Console.WriteLine("Distance du chemin : " + lesDixMeilleursChemins[i].getDistance());
			}
		}

		/**
		 * Renvoie les dix meilleurs chemins en fonction de leur score
		 
		public static List<Chemin> dixMeilleursChemins(List<Chemin> lesChemins)
		{
			List<Chemin> finalChemin = lesChemins;

			finalChemin = finalChemin.OrderBy(o => o.getDistance()).ToList<Chemin>();

			finalChemin = finalChemin.GetRange(0, 10);

			return finalChemin;
		}
	}

	/**
	 * Class Evaluate
	 * 
	 * Donne les méthodes pour évaluer les chemins 
	 * 
	 
	public abstract class Evaluate
	{

		public float evaluate(Dictionary<int, Chemin> leChemin)
		{
			float scoreFinal = 0f;

			foreach(Chemin unChemin in leChemin.Values)
			{
				scoreFinal += unChemin.getDistance();
			}

			return scoreFinal;
		}
	}

	/**
	 * Class Ville
	 * 
	 * Défini l'objet Ville
	 
	public class Ville
	{
		public string nom;
		public int id;
		public float x;
		public float y;

		public Ville(string nom, int id, float x, float y)
		{
			this.nom = nom;
			this.id = id;
			this.x = x;
			this.y = y;
		}

		public int getId()
		{
			return this.id;
		}

		public float getX()
		{
			return this.x;
		}

		public float getY()
		{
			return this.y;
		}
	} 


	/**
	 * Class Chemin
	 * 
	 * Défini l'objet Chemin
	 
	public class Chemin {

		int[] cheminsId;

		public Chemin(List<Ville> lesVilles)
		{
			for(int i = 0; i < lesVilles.Count; i++)
			{
				this.cheminsId.Append(lesVilles[i].getId());
			}
		}

		/**
		 * Donne la distance entre les deux villes
		 
		public float getDistance()
		{
			float totalDistance = 0f;

			for(int i = 0; i < this.cheminsId.Length -1; i++)
			{
				// totalDistance += Math.Abs((this.lesVilles.GetValueOrDefault(i).getX() - this.lesVilles.GetValueOrDefault(i+1).getX()) - (this.lesVilles.GetValueOrDefault(i).getY() - this.lesVilles.GetValueOrDefault(i+1).getY())); ;
				totalDistance += Math.Abs()
			}
			return totalDistance;
		}

		public string montrerLettreVille()
		{
			//return this.villeA.getLettre() + " / " + this.villeB.getLettre() + " / Distance : " + this.getDistance();
			return null;
		}
	}


	/**
	static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Sauvegarde mySvg = new Sauvegarde(1, "Un beau titre", "Un super nom", "Un super prénom");
			afficherAttribut(mySvg);

			GenericList<int> list1 = new GenericList<int>();
			GenericList<string> list2 = new GenericList<string>();
			GenericList<Sauvegarde> listSauvegarde = new GenericList<Sauvegarde>();

			Console.WriteLine("Exo générique");

			afficherAttribut(list1);
			afficherAttribut(list2);
			afficherAttribut(listSauvegarde);
		}


		public static void afficherAttribut(Object mySvg)
		{
			Type myType = mySvg.GetType();

			foreach (MethodInfo mInfo in myType.GetMethods())
			{
				Console.WriteLine(mInfo);

				foreach (Attribute svg in mInfo.GetCustomAttributes())
				{
					if (svg.GetType() == typeof(Sauvegarde))
					{
						Console.WriteLine(svg.GetType() + " & " + typeof(Sauvegarde) + " sont égaux !");
					}
				}
			}
			Console.ReadKey();
		}

	}

	public class Sauvegarde : Attribute
	{
		public int id;
		public string titre;
		public string nomPerso;
		public string prenomPerso;

		public Sauvegarde(int id, string titre, string nom, string prenom)
		{
			this.id = id;
			this.titre = titre;
			this.nomPerso = nom;
			this.prenomPerso = prenom;

		}


	}

	public class GenericList<T>
	{
		void Add(T input)
		{
		}
	}
	*/

