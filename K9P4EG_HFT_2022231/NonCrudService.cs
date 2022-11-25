using K9P4EG_HFT_2022231.Logic;
using K9P4EG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Client
{
      class NonCrudService
    {

        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }

        public void AvgWeight()
        {
            double item = rest.GetSingle<double>("NonCrud/AvgWeight");
            Console.WriteLine($"Avarage weight: {item} tonns");
            Console.ReadLine();
        }


        public void BigestGun()
        {
            double item = rest.GetSingle<double>("NonCrud/BigestGun");
            Console.WriteLine($"Biggest gun size : {item} mm");
            Console.ReadLine();
        }

        public void ReadCountryStats()
        {
            var items = rest.Get<CountryStatistic>("NonCrud/ReadCountryStats");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void GetTanksByGunRange()
        {
            Console.WriteLine("Min=");
            int min = int.Parse(Console.ReadLine());

            Console.WriteLine("Max=");
            int max = int.Parse(Console.ReadLine());

            var items = rest.Get<Tank>($"NonCrud/GetTanksByGunRange?min={min}&max={max}");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void StrongerCountry()
        {
            var item = rest.GetSingle<Country>("NonCrud/StrongerCountry");
            Console.WriteLine(item);
            Console.ReadLine();
        }
    }
}
