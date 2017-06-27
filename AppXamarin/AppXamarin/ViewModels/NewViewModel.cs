using AppXamarin.Models;
using AppXamarin.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarin.ViewModels
{
    class NewViewModel : BindableObject
    {
        string _nombre;
        string _descripcion;
        Command _cmdCrear;

        public string CityNombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("CityNombre");
            }
        }

        public string CityDescripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
                OnPropertyChanged("CityDescripcion");
            }
        }

        public ICommand CmdCrear
        {
            get { return _cmdCrear = _cmdCrear ?? new Command(CmdCrearExecute); }
        }

        public void CmdCrearExecute()
        {
            AzureService _azureService = AzureService.Instance;
            City _newCity = new City { Name = CityNombre, Description = CityDescripcion };

            _azureService.InsertUpdateCity(_newCity);
        }
    }
}
