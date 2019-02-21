using SmartHomeClient.Views;
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
    public partial class MainTabbedPage : TabbedPage
    {
        //Create objects for each tab.
        //var locationTab = new Location();       // Location consist of map that shows relative user's location with respect to home location. Using Google map web API.
        public MainTabbedPage(string serverIP)
        {
            InitializeComponent();

            //Hide navigation button/bar
            //NavigationPage.SetHasBackButton(this, false);

            NavigationPage.SetHasNavigationBar(this, false);
            SchedulePage scheduleTab = new SchedulePage();
            MainPage switchTab = new MainPage(serverIP);         //MainPage consist of switch panel.
            AnalyticPage analyticTab = new AnalyticPage();   // AnalyticPage consist of chart of load usage.

            switchTab.Title = "Switch";
            analyticTab.Title = "Analytic";
            //locationTab.Title = "Location";
            scheduleTab.Title = "Schedule";

            //Add those objects in each tab in MainTabbedPage
            Children.Add(switchTab);
            Children.Add(scheduleTab);
            Children.Add(analyticTab);


        }

    }
}