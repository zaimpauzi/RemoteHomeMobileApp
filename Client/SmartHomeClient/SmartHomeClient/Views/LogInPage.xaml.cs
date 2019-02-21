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
	public partial class LogInPage : ContentPage
	{
        //Initialized main tabbed page object.
        string defaultServerIP = "192.168.1.2";
        SettingPage settingPage = new SettingPage();

        public LogInPage ()
		{
            //Entrance page which request for credential to enter the app.
			InitializeComponent ();
            settingPage.serverIP = defaultServerIP;
            progressIndicator.IsVisible = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            progressIndicator.IsVisible = true;
            string username = "admin"; //temporarily hardcoded the username.
            string password = "sysadmin"; //temporarily hardcoded the password.
             
            //Check if the input username and password by user are match with the parameters set up.
            if ((usernameEntry.Text == username) && (passwordEntry.Text ==  password))
            {
                statusLabel.Text = "";
                //Navigate to the tabbed page.
                MainTabbedPage switchingPage = new MainTabbedPage(settingPage.serverIP);
                await Navigation.PushAsync(switchingPage);

            }

            //Show error if wrong username or password input by user.
            else
            {
                statusLabel.Text = "Wrong username or password!";
            }

            progressIndicator.IsVisible = false;

        }

        private async void SettingBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(settingPage);
        }
    }
}