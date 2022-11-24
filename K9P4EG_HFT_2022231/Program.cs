using K9P4EG_HFT_2022231.Logic;
using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository;
using K9P4EG_HFT_2022231.Repository.Database;
using K9P4EG_HFT_2022231.Repository.Interface;
using System;
using System.Linq;

namespace K9P4EG_HFT_2022231
{
    class Program
    {
        static void Main(string[] args)
        {
            TankDbContex db = new TankDbContex();
            var q1 = db.Tanks.ToArray();
            var q2 = db.Battles.ToArray();
            var q3 = db.Countries.ToArray();

            var repo = new TankRepository(db);
            var repo2 = new CountryRepository(db);
            var log = new TankLogic(repo);
            var log2 = new CountryLogic(repo2);


            var items = log.ReadAll();
            var t = log.BigestGun();
            var x = log.ReadCountryStats();
            var minmax = log.GetTanksByGunRange(110, 160);
            var best = log2.StrongerCountry();
            ;
            ;
        }
    }
}
