using Newtonsoft.Json;
using SmartHomeClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHomeClient.Views
{
    public delegate void MyEventHandler(object sender, EventArgs e);

    public partial class MainPage : ContentPage

    {
        public event MyEventHandler readSwitchStateEvent;
        private bool isReadSwitchState;
        private string serverIP;
        public MainPage(string _serverIP)
        {
            InitializeComponent();
            serverIP = _serverIP;
            readSwitchStateEvent += MainPage_readSwitchStateEventHandler;
            readSwitchStateEvent(this, new EventArgs());
        }

        private async void MainPage_readSwitchStateEventHandler(object sender, EventArgs e)
        {
            string switchState = null;
            string exitCode = "0";
            string sqlResponse = "";
            string requestSwitchStateUri = $"http://{serverIP}/RequestSwitchState.php";
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(requestSwitchStateUri);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 0, 5);

            try
            {
                progressIndicator.IsVisible = true;
                HttpResponseMessage response = await client.SendAsync (request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                HttpContent content = response.Content;
                string json = await content.ReadAsStringAsync();
                SQLObject _sqlObject = JsonDeserializer(json);
                switchState = _sqlObject.switchState;
                exitCode = _sqlObject.exitCode;
                sqlResponse = _sqlObject.sqlResponse;
                isReadSwitchState = true;
                if (switchState == "1")
                {
                    lampSwitch.IsToggled = true;
                    lampImage.Source = "on.png";
                    //stateLabel.Text = "Lamp is ON";
                    this.BackgroundColor = Color.LightYellow;
                }

                else
                {
                    lampSwitch.IsToggled = false;
                    lampImage.Source = "off.png";
                    //stateLabel.Text = "Lamp is OFF";
                    this.BackgroundColor = Color.DarkGray;

                }
                isReadSwitchState = false;
                progressIndicator.IsVisible = false;

                }
                else
                {
                    progressIndicator.IsVisible = false;
                    await DisplayAlert("Alert", "Database server unreachable!", "OK");
                }
            }

            catch (Exception)
            {
                progressIndicator.IsVisible = false;
                await DisplayAlert("Alert", "Server unreachable!", "OK");
            }

        }

        public static SQLObject JsonDeserializer(string json)
        {
            SQLObject results = JsonConvert.DeserializeObject<SQLObject>(json);
            return results;
        }

        private async void lampSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            string exitCode = "0";
            string sqlResponse = "";
            const string switchOFF = "0";
            const string switchON = "1";
            string updateSwitchStateUri = $"http://{serverIP}/UpdateSwitchState.php?state=";

            if (!isReadSwitchState)
            {
                if (!lampSwitch.IsToggled)
                {
                    lampImage.Source = "off.png";
                    //stateLabel.Text = "Lamp is OFF";
                    this.BackgroundColor = Color.DarkGray;

                    var request = new HttpRequestMessage();
                    request.RequestUri = new Uri($"{updateSwitchStateUri}{switchOFF}");
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");
                    var client = new HttpClient();
                    client.Timeout = new TimeSpan(0, 0, 0, 5);

                    try
                    {
                        progressIndicator.IsVisible = true;
                        HttpResponseMessage response = await client.SendAsync(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            HttpContent content = response.Content;
                            string json = await content.ReadAsStringAsync();
                            SQLObject _sqlObject = JsonDeserializer(json);
                            exitCode = _sqlObject.exitCode;
                            sqlResponse = _sqlObject.sqlResponse;
                            progressIndicator.IsVisible = false;

                        }
                        else
                        {
                            progressIndicator.IsVisible = false;
                            await DisplayAlert("Alert", "Database server unreachable!", "OK");
                        }

                    }
                    catch (Exception)
                    {
                        progressIndicator.IsVisible = false;
                        await DisplayAlert("Alert", "Server unreachable!", "OK");
                    }


                }

                if (lampSwitch.IsToggled)
                {
                    lampImage.Source = "on.png";
                    //stateLabel.Text = "Lamp is ON";
                    this.BackgroundColor = Color.LightYellow;

                    var request = new HttpRequestMessage();
                    request.RequestUri = new Uri($"{updateSwitchStateUri}{switchON}");
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");
                    var client = new HttpClient();
                    client.Timeout = new TimeSpan(0, 0, 0, 5);
                    try
                    {
                        progressIndicator.IsVisible = true;
                        HttpResponseMessage response = await client.SendAsync(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            HttpContent content = response.Content;
                            string json = await content.ReadAsStringAsync();
                            SQLObject _sqlObject = JsonDeserializer(json);
                            exitCode = _sqlObject.exitCode;
                            sqlResponse = _sqlObject.sqlResponse;
                            progressIndicator.IsVisible = false;
                        }
                        else
                        {
                            progressIndicator.IsVisible = false;
                            await DisplayAlert("Alert", "Database server unreachable!", "OK");
                        }
                    }

                    catch (Exception)
                    {
                        progressIndicator.IsVisible = false;
                        await DisplayAlert("Alert", "Server unreachable!", "OK");
                    }
                }
            }

            if (exitCode == "1")
            {
                await DisplayAlert("Alert", sqlResponse, "OK");

            }

        }

       
    }



}
