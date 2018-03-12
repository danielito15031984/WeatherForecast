using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private WeatherForecastContext _weatherForecastContext;

        public WeatherForecastRepository(WeatherForecastContext weatherForecastContext)
        {
            _weatherForecastContext = weatherForecastContext;
        }

        public IEnumerable<WeatherForecastEntity> GetWeatherForecastLog()
        {
            return _weatherForecastContext.WeatherForecastLog.ToList();
        }

        public void Add(WeatherForecastEntity entity)
        {
            _weatherForecastContext.WeatherForecastLog.Add(entity);
            _weatherForecastContext.SaveChanges();
        }
    }
}
