using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp_maccarinelli_fernandez
    {
    public class Ville
    {
        public Double Longitude { get; set; }
        public Double Latitude { get; set; }

        public string Nom { get; set; }

        public Ville(Double Longitude, Double Latitude, string Nom)
        {
            this.Longitude = Longitude;
            this.Latitude = Latitude;
            this.Nom = Nom;
        }

        /**
         * Renvoi la distance entre deux villes
         */
        public Double distance(Ville villeDepart, Ville villeDarrivee)
        {
            Double DistanceX = 0.0;
            Double DistanceY = 0.0;
            Double Distance = 0.0;

            DistanceX = (Double)(villeDepart.Longitude) * 40000.0 * (Double)Math.Cos((villeDepart.Latitude + villeDarrivee.Latitude) * (Double)Math.PI / 360.0) / 360.0;
            DistanceY = (Double)Math.Abs(villeDepart.Latitude - villeDarrivee.Latitude) * 40000.0 / 360.0;

            Distance = (Double)Math.Sqrt(Math.Abs((DistanceX) * (DistanceY) + ((DistanceY) * (DistanceX))));

            return Distance;
        }
    }


}
