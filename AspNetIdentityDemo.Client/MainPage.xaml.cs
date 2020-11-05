using AspNetIdentityDemo.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AspNetIdentityDemo.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string accessToken = e.Parameter.ToString();

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.GetAsync("http://localhost:55443/weatherforecast");

            var responseBody = await response.Content.ReadAsStringAsync();

            var weatherForecasts = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseBody);

            lstWeatherForecast.ItemsSource = weatherForecasts;

        }
    }
}