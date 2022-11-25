using K9P4EG_HFT_2022231.Logic;
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
    public class BattleController : ControllerBase
    {
        IBattleLogic BattleLogic;

        public BattleController(IBattleLogic battleLogic)
        {
            BattleLogic = battleLogic;
        }

        // GET: api/<TankController>
        [HttpGet]
        public IEnumerable<Battle> ReadAll()
        {
            return this.BattleLogic.ReadAll();
        }

        // GET api/<TankController>/5
        [HttpGet("{id}")]
        public Battle Read(int id)
        {
            return this.BattleLogic.Read(id);
        }

        // POST api/<TankController>
        [HttpPost]
        public void Create([FromBody] Battle value)
        {
            this.BattleLogic.Create(value);
        }
        // PUT api/<TankController>/5
        [HttpPut]
        public void Update([FromBody] Battle value)
        {
            this.BattleLogic.Update(value);
        }

        // DELETE api/<TankController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.BattleLogic.Delete(id);
        }
    }
}
