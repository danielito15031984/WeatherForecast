using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenWeather
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> GetWeatherForecast(string zipCode)
        {
            var result = await FetchForecast(zipCode);
            return result;
        }

        private async Task<string> FetchForecast(string zipCode)
        {
            string msg;

            var stringTask = client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid=226b296d6a1422fd4122a8eec5934d3d");
            try
            {
                msg = await stringTask;
            }
            catch (Exception ex)
            {
                return "";
            }
            

            dynamic json = JsonConvert.DeserializeObject(msg);

            float tempFarenheit = json.main.temp;
            tempFarenheit = float.Parse(CovertTemperature(tempFarenheit));

            var weatherDTO = new
            {
                description = json.weather[0].description,
                temperature = (int)tempFarenheit,
                iconUrl = $"http://openweathermap.org/img/w/{json.weather[0].icon}.png"
            };

            return JsonConvert.SerializeObject(weatherDTO);
        }

        private string CovertTemperature(float temperature) => (temperature * 9 / 5 - 459.67).ToString();

    }
}
