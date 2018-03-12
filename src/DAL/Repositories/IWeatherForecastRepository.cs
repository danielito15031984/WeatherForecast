using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecastEntity> GetWeatherForecastLog();
        void Add(WeatherForecastEntity entity);
    }
}
