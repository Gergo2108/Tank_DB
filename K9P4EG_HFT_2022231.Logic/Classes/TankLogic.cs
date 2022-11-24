using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K9P4EG_HFT_2022231.Logic;
using K9P4EG_HFT_2022231.Logic.Interfaces;
using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository.Interface;

namespace K9P4EG_HFT_2022231.Logic
{
    public class TankLogic : ITankLogic
    {
        Repo<Tank> repo;

        public TankLogic(Repo<Tank> repo)
        {
            this.repo = repo;
        }

       

        public void Create(Tank item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Tank Read(int id)
        {
            var tank = this.repo.Read(id);
            if (tank == null)
            {
                throw new ArgumentException("Tank not exissts");
            }
            return tank;
        }

        public IEnumerable<Tank> ReadAll()
        {
           return this.repo.ReadAll();
        }

        public void Update(Tank item)
        {
            this.repo.Update(item);
        }

        //Non-CRUD
        public double AvgWeight()
        {
            return this.repo.ReadAll().Average(t => t.Weight);
        }

        public double BigestGun()
        {
            return this.repo.ReadAll().Max(t => t.GunSize);
        }

        public IEnumerable<CountryStatistic> ReadCountryStats()
        {
            var countrystat = from tank in this.repo.ReadAll()
                              group tank by tank.Country.Name into g
                              select new CountryStatistic()
                              {
                                  CountryName = g.Key,
                                  TankCount = g.Count(),

                              };
            return countrystat;
        }

        public IEnumerable<Tank> GetTanksByGunRange(int min, int max)
        {
            return from tank in repo.ReadAll()
                   where min <= tank.GunSize && tank.GunSize <= max
                   select tank;

        }

        
    }
}
