using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_maccarinelli_fernandez
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Program mainProgram;
        List<Ville> lesVilles;
        //Thread mainThread = new Thread();
        public static Mutex m = new Mutex();

        // Recupération du lien de la BDD et instanciations
        static string _dbPath = "MyDatabase.db3";
        SQLiteConnection connection;


        private ObservableCollection<Ville> villes = new ObservableCollection<Ville>();
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }




        public MainWindow()
        {
            InitializeComponent();

            this.mainProgram = new Program();

            // On créer le fichier de BDD
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
            }

            this.connection = new SQLiteConnection("data source=" + _dbPath);
            this.connection.Open();
            Console.WriteLine(this.connection);
            SQLiteCommand sqlCommand = new SQLiteCommand(this.connection);

            // Si elle n'existe pas, on créer la table
            sqlCommand.CommandText =
                @"DROP TABLE VILLE";
            sqlCommand.ExecuteNonQuery();

            // Si elle n'existe pas, on créer la table
            sqlCommand.CommandText =
                @"CREATE TABLE IF NOT EXISTS [VILLE](
                [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                [Nom] NVARCHAR(2048) NULL,
                [Longitude] NUMERIC(2048) NULL,
                [Latitude] NUMERIC(2048) NULL
                )";
            sqlCommand.ExecuteNonQuery();

            // Insersiton d'une ligne de test
            sqlCommand.CommandText =
                @"INSERT INTO VILLE (Nom, Longitude, Latitude) VALUES ('Clermont - Ferrand', '3.002556', '45.846117'),
                ('Bordeaux', -0.644905, 44.896839),
                ('Bayonne', -1.380989, 43.470961),
                ('Toulouse', 1.376579, 43.662010), 
                ('Marseille', 5.337151, 43.327276), 
                ('Nice', 7.265252, 43.745404), 
                ('Nantes', -1.650154, 47.385427),
                ('Rennes', -1.430427, 48.197310),
                ('Paris', 2.414787, 48.953260), 
                ('Lille', 3.090447, 50.612962), 
                ('Dijon', 5.013054, 47.370547), 
                ('Valence', 4.793327, 44.990153), 
                ('Aurillac', 2.447746, 44.966838), 
                ('Orleans', 1.750115, 47.980822), 
                ('Reims', 4.134148, 49.323421), 
                ('Strasbourg', 7.506950, 48.580332), 
                ('Limoges', 1.233757, 45.865246), 
                ('Troyes', 4.047255, 48.370925), 
                ('Le Havre', 0.103163, 49.532415), 
                ('Cherbourg', -1.495348, 49.667704),
                ('Brest', -4.494615, 48.447500),
                ('Niort', -0.457140, 46.373545)";
            sqlCommand.ExecuteNonQuery();

            // Récupération de la ligne de test
            sqlCommand.CommandText =
                @"Select * FROM VILLE";
            SQLiteDataReader reader = sqlCommand.ExecuteReader();

            while(reader.Read())
            {
                double longitude = Convert.ToDouble(reader["Longitude"]);
                double latitude = Convert.ToDouble(reader["Latitude"]);
                string nom = reader["nom"].ToString();
                this.lesVilles.Add(new Ville(longitude, latitude, nom));
            }

            Console.WriteLine(this.lesVilles.Count);
     
            DataGrid dataGrid = new DataGrid();

            this.NotifyPropertyChanged("Longitude");
        }

        public static Object _lock = new Object();

        // lock(_lock)

        // public delegate void fkfk() {}

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }


}