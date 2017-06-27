using AppXamarin.Models;
using AppXamarin.Services;
using Xamarin.Forms;

namespace AppXamarin.Views
{
    public partial class MainView : ContentPage
    {
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

            botonVistaNuevo.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new NewView());
            };
        }
        
        public async void ViewGetCiudades()
        {
            AzureService _azureService = AzureService.Instance;
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
