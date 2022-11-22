
using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Repository
{
   public class TankRepository : GenericRepository<Tank>
    {
        public TankRepository(TankDbContex ctx) :base(ctx)
        {
        }

        public override Tank Read(int id)
        {
            return ctx.Tanks.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Tank item)
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
