using ConsoleTools;
using K9P4EG_HFT_2022231.Client;
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
            //TankDbContex db = new TankDbContex();
            //var q1 = db.Tanks.ToArray();
            //var q2 = db.Battles.ToArray();
            //var q3 = db.Countries.ToArray();

            //var repo = new TankRepository(db);
            //var repo2 = new CountryRepository(db);
            //var log = new TankLogic(repo);
            //var log2 = new CountryLogic(repo2);


            //var items = log.ReadAll();
            //var t = log.BigestGun();
            //var x = log.ReadCountryStats();
            //var minmax = log.GetTanksByGunRange(110, 160);
            //var best = log2.StrongerCountry();

            RestService rest = new RestService("http://localhost:5000/", typeof(Tank).Name);
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var tank = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Tank>())
                .Add("Create", () => crud.Create<Tank>())
                .Add("Delete", () => crud.Delete<Tank>())
                .Add("Update", () => crud.Update<Tank>())
                .Add("Exit", ConsoleMenu.Close);

            var country = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Country>())
                 .Add("Create", () => crud.Create<Country>())
                 .Add("Delete", () => crud.Delete<Country>())
                 .Add("Update", () => crud.Update<Country>())
                 .Add("Exit", ConsoleMenu.Close);


            var battle = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Battle>())
                .Add("Create", () => crud.Create<Battle>())
                .Add("Delete", () => crud.Delete<Battle>())
                .Add("Update", () => crud.Update<Battle>())
                .Add("Exit", ConsoleMenu.Close);


            var statsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Average tank weight", () => nonCrud.AvgWeight())
                .Add("Biggest gun", () => nonCrud.BigestGun())
                .Add("Tanks by guns", () => nonCrud.GetTanksByGunRange())
                .Add("Country stats", () => nonCrud.ReadCountryStats())
                .Add("Stronger Country", () => nonCrud.StrongerCountry())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Tanks", () => tank.Show())
                .Add("Countries", () => country.Show())
                .Add("Battles", () => battle.Show())
                .Add("Non-CRUD", () => statsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
