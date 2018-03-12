using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeather
{
    public interface IOpenWeatherService
    {
        Task<string> GetWeatherForecast(string zipCode);
    }
}
