using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHomeClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Location : ContentPage
    {
        public Location()
        {
            InitializeComponent();
            GetCurrentLocationAsync();
        }

        private async void GetCurrentLocationAsync()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(timeout: null);

            string longitude = position.Longitude.ToString();

            string latitude = position.Latitude.ToString();

            locationView.Source = $"https://www.google.com/maps/dir/{latitude}, {longitude}/5.1646744,100.5114819/";
        }

       
    }
}