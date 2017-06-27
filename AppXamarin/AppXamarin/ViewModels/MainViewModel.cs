using AppXamarin.Models;
using AppXamarin.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarin.ViewModels
{
    public class MainViewModel : BindableObject
    {
        ObservableCollection<City> _items;
        City _selectedItem;
        INavigation navigationContext;
        Command _cmdNewCity;

        public MainViewModel(INavigation context)
        {
            try
            {
                navigationContext = context;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public ICommand CmdNewCity
        {
            get { return _cmdNewCity = _cmdNewCity ?? new Command(CmdNewCityExecute); }
        }

        public void CmdNewCityExecute()
        {
            navigationContext.PushAsync(new Views.NewView());
        }


        public ObservableCollection<City> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public City SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                navigationContext.PushAsync(new Views.DetailView(_selectedItem));
            }
        }

        public async void OnAppearing()
        {
            var result = await AzureService.Instance.GetCities();

            if (result != null)
            {
                Items = new ObservableCollection<City>(result);
            }                
        }
    }
}
