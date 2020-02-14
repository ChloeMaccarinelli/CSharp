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
    public partial class MainWindow : Window, INotifyPropertyChanged 
    {
        Program mainProgram;
        public List<Ville> lesVilles { get; set; } = new List<Ville>();
        public List<Generation> lesGenerations { get; set; } = new List<Generation>();

        public Canvas mapImage { get; set; }
        public List<Ellipse> mapEllipses { get; set; }

        public int nbPopulation { get; set; }

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
            this.DataContext = this;
            this.mainProgram = new Program();
            this.lesGenerations = new List<Generation>();

            // On créer le fichier de BDD
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
            }

            this.connection = new SQLiteConnection("data source=" + _dbPath);
            this.connection.Open();
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
        }


        public static Object _lock = new Object();

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas canvas = (Canvas)sender;
            Point clickPoint = e.GetPosition(canvas);


            Ellipse ellipse = new Ellipse()
            { Stroke = Brushes.Red, StrokeThickness = 10
            };
            Canvas.SetTop(ellipse, clickPoint.Y - 5);
            Canvas.SetLeft(ellipse, clickPoint.X - 5);
            // ellipse.TranslatePoint(new Point(clickPoint.X, clickPoint.Y), this);

            canvas.Children.Add(ellipse);

            this.NotifyPropertyChanged("mapImage");
            string nomVille = "Ville" + this.lesVilles.Count + 1;


            SQLiteCommand sqlCommand = new SQLiteCommand(this.connection);
            String commandString = @"INSERT INTO VILLE(Longitude, Latitude, Nom) VALUES ('" + clickPoint.X + "', '" + clickPoint.Y + "', '" + nomVille + "')";
            sqlCommand.CommandText = commandString;
            sqlCommand.ExecuteNonQuery();


            this.lesVilles.Add(new Ville(clickPoint.Y, clickPoint.X, nomVille));

            this.NotifyPropertyChanged("lesVilles");
            datagrid.Items.Refresh();
        }

        private void Execute_Algorithme(object sender, RoutedEventArgs e)
        {
            this.mainProgram = new Program();
            this.lesGenerations = new List<Generation>();

            this.NotifyPropertyChanged("lesGenerations");

            this.mainProgram.initialiseChemins();
            this.mainProgram.execute(nbPopulation, this.lesVilles);

            this.lesGenerations = this.mainProgram.getGenerations();

            this.NotifyPropertyChanged("lesGenerations");
        }
    }
}