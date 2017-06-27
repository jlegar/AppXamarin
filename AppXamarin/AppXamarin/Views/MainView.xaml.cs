using AppXamarin.ViewModels;
using Xamarin.Forms;

namespace AppXamarin.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            Title = "CIUDADES ASOMBROSAS";
            BindingContext = new MainViewModel(Navigation);
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = BindingContext as MainViewModel;
            if (viewModel != null) viewModel.OnAppearing();
        }
    }
}
