using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Repository
{
    public class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(TankDbContex ctx) : base(ctx)
        {
                
        }
        public override Country Read(int id)
        {
            return ctx.Countries.FirstOrDefault(c => c.Id == id);
        }

        public override void Update(Country item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
