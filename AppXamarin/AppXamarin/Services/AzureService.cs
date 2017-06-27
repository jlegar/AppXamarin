using Microsoft.WindowsAzure.MobileServices;
using AppXamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace AppXamarin.Services
{
    public class AzureService
    {
        const string AzureEndPoint = "http://xamagramnetbackendjlg.azurewebsites.net";
        MobileServiceClient mobileService;
        IMobileServiceTable<City> mobileTableCity;
        private static AzureService _instance;


        public static AzureService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AzureService();
                }
                return _instance;
            }
        }

        public AzureService()
        {
            if (mobileService != null)
                return;

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

        public void InsertUpdateCity(City city)
        {
            try
            {
                var result = mobileTableCity.Where(expr => expr.Name.Contains(city.Name)).ToEnumerableAsync();
                
                if (city.Id != null)
                    mobileTableCity.UpdateAsync(city);
                else
                    mobileTableCity.InsertAsync(city);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
