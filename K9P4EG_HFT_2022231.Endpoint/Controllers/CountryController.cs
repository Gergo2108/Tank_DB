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
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryLogic CountrLogic;

        public CountryController(ICountryLogic countrLogic)
        {
            CountrLogic = countrLogic;
        }

        // GET: api/<TankController>
        [HttpGet]
        public IEnumerable<Country> ReadAll()
        {
            return this.CountrLogic.ReadAll();
        }

        // GET api/<TankController>/5
        [HttpGet("{id}")]
        public Country Read(int id)
        {
            return this.CountrLogic.Read(id);
        }

        // POST api/<TankController>
        [HttpPost]
        public void Create([FromBody] Country value)
        {
            this.CountrLogic.Create(value);
        }
        // PUT api/<TankController>/5
        [HttpPut]
        public void Update([FromBody] Country value)
        {
            this.CountrLogic.Update(value);
        }

        // DELETE api/<TankController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.CountrLogic.Delete(id);
        }
    }
}
