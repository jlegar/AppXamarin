using AppXamarin.Models;
using AppXamarin.Services;
using Xamarin.Forms;

namespace AppXamarin.Views
{
    public partial class MainView : ContentPage
    {
        //public IEnumerable<City> Cities { get; set; }

        public MainView()
        {
            InitializeComponent();
            Title = "CIUDADES ASOMBROSAS";
            BindingContext = new ViewModels.MainViewModel();
            ViewGetCiudades();

            CitiesView.ItemSelected += (sender, e) =>
            {
                if (CitiesView.SelectedItem != null)
                {
                    Navigation.PushAsync(new DetailView(e.SelectedItem as City));
                    CitiesView.SelectedItem = null;
                }
            };
        }
        
        public async void ViewGetCiudades()
        {
            AzureService _azureService = new AzureService();
            CitiesView.ItemsSource = await _azureService.GetCities();
        }
        /*
        protected override void OnAppearing()
        {
            GetCities();
            CitiesView.ItemsSource = Cities;
        }
        */
    }
}
