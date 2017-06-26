using Microsoft.WindowsAzure.MobileServices;
using AppXamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace AppXamarin.Services
{
    class AzureService
    {
        const string AzureEndPoint = "http://xamagramnetbackendjlg.azurewebsites.net";
        MobileServiceClient mobileService;
        IMobileServiceTable<City> mobileTableCity;

        public AzureService()
        {
            mobileService = new MobileServiceClient(AzureEndPoint);
            mobileTableCity = mobileService.GetTable<City>();
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            try
            {
                var cities = await mobileTableCity.ToEnumerableAsync();
                return cities;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public void PutCity(City city)
        {
            try
            {
                mobileTableCity.InsertAsync(city);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
