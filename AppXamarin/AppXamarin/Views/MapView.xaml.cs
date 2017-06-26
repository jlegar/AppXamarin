using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppXamarin.Views
{
    public partial class MapView : ContentPage
    {
        public MapView(string city)
        {
            double latitud = 37.7749300;
            double longitud = -122.4194200;

            InitializeComponent();
            Title = "Mapa de " + city;

            switch (city)
            {
                case "Nueva York":
                    latitud = 40.712852;
                    longitud = -74.002730;
                    break;
                case "París":
                    latitud = 48.856805;
                    longitud = 2.350302;
                    break;
                case "Roma":
                    latitud = 41.901809;
                    longitud = 12.498912;
                    break;
                case "San Francisco":
                    latitud = 37.775863;
                    longitud = -122.418376;
                    break;
                case "Seattle":
                    latitud = 47.605504;
                    longitud = -122.329733;
                    break;
                case "Sevilla":
                    latitud = 37.388445;
                    longitud = -5.990422;
                    break;
            }
            CityMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitud, longitud), Distance.FromMiles(5)));
        }
    }
}
