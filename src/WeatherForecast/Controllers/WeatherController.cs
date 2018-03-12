using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherForecast.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        public readonly IOpenWeatherService _openWeatherService;
        public IWeatherForecastRepository _weatherForecastRepository;

        public WeatherController(IOpenWeatherService openWeatherService, IWeatherForecastRepository weatherForecastRepository)
        {
            _openWeatherService = openWeatherService;
            _weatherForecastRepository = weatherForecastRepository;
        }

        // GET api/weather/zipCode
        [HttpGet("{zipCode}")]
        public IActionResult Get(string zipCode)
        {
            if (zipCode != string.Empty)
            {
                var response = _openWeatherService.GetWeatherForecast(zipCode);
                if (response.Result != "")
                {
                    AddLog(response.Result, zipCode);
                    
                    return Ok(response.Result); 
                }
                else
                {
                    return NotFound("The Zip Code entered does not exists.");
                }
            }
            else
                return BadRequest("The Zip Code must be valid!");
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            return Ok(_weatherForecastRepository.GetWeatherForecastLog());
        }

        private void AddLog(string logData, string zipCode)
        {
            JObject json = JObject.Parse(logData);

            var dto = new WeatherForecastEntity
            {
                Timestamp = DateTime.Now,
                ZipCode = zipCode,
                Temperature = (int)json["temperature"]
            };

            _weatherForecastRepository.Add(dto);
        }

    }
}
