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
        string defaultServerIP = "192.168.1.2";
        SettingPage settingPage = new SettingPage();
        MainTabbedPage switchingPage;
        public LogInPage ()
		{
            //if (Device.RuntimePlatform == Device.Android)
            //{
            //    appImage.Source = "AppIcon.png";

            //}

            //if (Device.RuntimePlatform == Device.iOS)
            //{
            //}

            //Entrance page which request for credential to enter the app.
            InitializeComponent();
            settingPage.serverIP = defaultServerIP;
            switchingPage = new MainTabbedPage(settingPage.serverIP);    //Initialized main tabbed page object
            settingPage.Disappearing += SettingPage_Disappearing;
            progressIndicator.IsVisible = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            string username = "admin"; //temporarily hardcoded the username.
            string password = "sysadmin"; //temporarily hardcoded the password.
            
            //Check if the input username and password by user are match with the parameters set up.
            if ((usernameEntry.Text == username) && (passwordEntry.Text ==  password))
            {
                statusLabel.Text = "";
                progressIndicator.IsVisible = true;
                switchingPage.Disappearing += SwitchingPage_Disappearing;
                await Navigation.PushAsync(switchingPage);  //Navigate to the tabbed page.
                progressIndicator.IsVisible = false;

            }

            //Show error if wrong username or password input by user.
            else
            {
                statusLabel.Text = "Wrong username or password!";
            }
        }


        private async void SettingBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(settingPage);
        }

        private void SwitchingPage_Disappearing(object sender, EventArgs e)
        {
            switchingPage = new MainTabbedPage(settingPage.serverIP);    //Initialized main tabbed page object
        }

        private void SettingPage_Disappearing(object sender, EventArgs e)
        {
            switchingPage = new MainTabbedPage(settingPage.serverIP);    //Initialized main tabbed page object
        }
    }
}