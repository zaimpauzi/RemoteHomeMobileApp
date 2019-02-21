using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;

namespace SmartHomeClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnalyticPage : ContentPage
	{
        
		public AnalyticPage ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var entries = new[]
            {
                 new Microcharts.Entry(12)
                    {
                        Label = "Monday",
                        ValueLabel = "12",
                        Color = SKColor.Parse("#266489"),
                        TextColor = SKColor.Parse("#000000")
                    },
                new Microcharts.Entry(24)
                    {
                        Label = "Tuesday",
                        ValueLabel = "24",
                        Color = SKColor.Parse("#68B9C0"),
                        TextColor = SKColor.Parse("#000000")
                    },
                new Microcharts.Entry(5)
                    {
                        Label = "Wednesday",
                        ValueLabel = "5",
                        Color = SKColor.Parse("#266489"),
                        TextColor = SKColor.Parse("#000000")
                    },

                new Microcharts.Entry((float)6.5)
                    {
                        Label = "Thursday",
                        ValueLabel = "6.5",
                        Color = SKColor.Parse("#68B9C0"),
                        TextColor = SKColor.Parse("#000000")
                    },

                new Microcharts.Entry(8)
                    {
                        Label = "Friday",
                        ValueLabel = "8",
                        Color = SKColor.Parse("#266489"),
                        TextColor = SKColor.Parse("#000000")
                    }
            };
            
            var chart = new BarChart() { Entries = entries };
            chart.LabelTextSize = 30;
            chart.PointSize = 30;
            chartView.Chart = chart;
        }

    }
}