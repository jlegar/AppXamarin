using AppXamarin.Models;
using Xamarin.Forms;

namespace AppXamarin.Views
{
    public partial class DetailView : ContentPage
    {
        public DetailView(City citySelected)
        {
            InitializeComponent();
            Title = citySelected.Name;
            BindingContext = new ViewModels.DetailViewModel(citySelected);

            BotonMaps.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new MapView(citySelected.Name));
            };
        }
    }
}
