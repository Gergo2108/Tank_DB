using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K9P4EG_HFT_2022231.Logic.Interfaces;
using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository.Interface;

namespace K9P4EG_HFT_2022231.Logic
{
    public class CountryLogic : ICountryLogic
    {
        Repo<Country> repo;

        public CountryLogic(Repo<Country> rep)
        {
            this.repo = rep;
        }
        public void Create(Country item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Country Read(int id)
        {
            var country = this.repo.Read(id);
            if (country == null)
            {
                throw new ArgumentException("Country not exissts");
            }
            return country;
        }

        public IEnumerable<Country> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Country item)
        {
            this.repo.Update(item);
        }

        //NON-CRUD

        public Country StrongerCountry()
        {
            var r = from c in repo.ReadAll()
                   orderby c.Tanks.Count descending
                   select new Country
                   {
                       Name = c.Name,
                       Tanks = c.Tanks,
                       Battles = c.Battles,
                       Id = c.Id
                   };
            return r.ToList().First();



        }
    }  
}
