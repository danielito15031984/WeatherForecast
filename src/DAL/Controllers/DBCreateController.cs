using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class DBCreateController : Controller
    {
        private IWeatherForecastRepository _repo;

        public DBCreateController(IWeatherForecastRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("api/createdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok(_repo.GetWeatherForecastLog());
        }
    }
}
