using AppXamarin.Models;
using Xamarin.Forms;

namespace AppXamarin.ViewModels
{
    class DetailViewModel : BindableObject
    {
        private string _cityName;
        private string _cityDescription;
        private string _cityImage;

        public DetailViewModel(City city)
        {
            _cityName = city.Name;
            _cityDescription = city.Description;
            _cityImage = city.Image;
        }

        public string CityName
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                OnPropertyChanged("CityName");
            }
        }

        public string CityDescription
        {
            get { return _cityDescription; }
            set
            {
                _cityDescription = value;
                OnPropertyChanged("CityDescription");
            }
        }

        public string CityImage
        {
            get { return _cityImage; }
            set
            {
                _cityImage = value;
                OnPropertyChanged("CityImage");
            }
        }
    }
}
