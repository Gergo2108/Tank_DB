using K9P4EG_HFT_2022231.Logic.Interfaces;
using K9P4EG_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace K9P4EG_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TankController : ControllerBase
    {
        ITankLogic TankLogic;

        public TankController(ITankLogic tankLogic)
        {
            TankLogic = tankLogic;
        }

        // GET: api/<TankController>
        [HttpGet]
        public IEnumerable<Tank> ReadAll()
        {
            return this.TankLogic.ReadAll();
        }

        // GET api/<TankController>/5
        [HttpGet("{id}")]
        public Tank Read(int id)
        {
            return this.TankLogic.Read(id);
        }

        // POST api/<TankController>
        [HttpPost]
        public void Create([FromBody] Tank value)
        {
            this.TankLogic.Create(value);
        }
        // PUT api/<TankController>/5
        [HttpPut]
        public void Update([FromBody] Tank value)
        {
            this.TankLogic.Update(value);
        }

        // DELETE api/<TankController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.TankLogic.Delete(id);
        }
    }
}
