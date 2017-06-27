using Xamarin.Forms;

namespace AppXamarin.Views
{
    public partial class NewView : ContentPage
    {
        public NewView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.NewViewModel();
            Title = "Nueva Ciudad";
        }
    }
}
