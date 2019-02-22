using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHomeClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
            scheduleStackLayout.IsEnabled = false;
            scheduleStackLayout.Opacity = 0.5;
        }

        private void ScheduleSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (scheduleSwitch.IsToggled)
            {
                scheduleStackLayout.IsEnabled = true;
                scheduleStackLayout.Opacity = 1;
            }

            else
            {
                scheduleStackLayout.IsEnabled = false;
                scheduleStackLayout.Opacity = 0.5;
            }
        }

        private async void SetScheduleBtn_Clicked(object sender, EventArgs e)
        {
            markImagePop.IsVisible = true;
            await Task.Delay(500);
            markImagePop.IsVisible = false;

        }
    }
}