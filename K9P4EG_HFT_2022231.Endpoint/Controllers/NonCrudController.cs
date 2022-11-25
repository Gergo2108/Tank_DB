using K9P4EG_HFT_2022231.Logic;
using K9P4EG_HFT_2022231.Logic.Interfaces;
using K9P4EG_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K9P4EG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        ITankLogic TankLogic;
        ICountryLogic CountryLogic;

        public NonCrudController(ITankLogic tankLogic, ICountryLogic countryLogic)
        {
            TankLogic = tankLogic;
            CountryLogic = countryLogic;
        }

        [HttpGet]
        public double AvgWeight()
        {
            return TankLogic.AvgWeight();
        }
        [HttpGet]
        public double BigestGun()
        {
            return TankLogic.BigestGun();
        }
        [HttpGet]
        public IEnumerable<CountryStatistic> ReadCountryStats()
        {
            return TankLogic.ReadCountryStats();
        }
        // GET api/<NonCrudController>/5
        [HttpGet]
        public IEnumerable<Tank> GetTanksByGunRange([FromQuery] int min, int max)
        {
            return TankLogic.GetTanksByGunRange(min, max);
        }
        [HttpGet]
        public Country StrongerCountry()
        {
            return CountryLogic.StrongerCountry();
        }


    }
}
