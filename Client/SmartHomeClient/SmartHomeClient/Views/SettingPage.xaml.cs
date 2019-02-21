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
	public partial class SettingPage : ContentPage
	{
        public string serverIP;
		public SettingPage ()
		{
			InitializeComponent ();
            serverIP = ipEntry.Text;

        }

        private void IpEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            serverIP = ipEntry.Text;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}