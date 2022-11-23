using K9P4EG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Logic.Interfaces
{
     public interface ITankLogic
    {
        void Create(Tank item);
        void Delete(int id);
        Tank Read(int id);
        IEnumerable<Tank> ReadAll();
        void Update(Tank item);
        //Non-CRUD
        double AvgWeight();
        double BigestGun();
        public IEnumerable<CountryStatistic> ReadCountryStats();
       
        
    }
}
