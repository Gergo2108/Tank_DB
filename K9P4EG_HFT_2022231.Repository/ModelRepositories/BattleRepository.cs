using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Repository
{
   public class BattleRepository : GenericRepository<Battle>
    {
        public BattleRepository(TankDbContex ctx) :base(ctx)
        {

        }

        public override Battle Read(int id)
        {
            return ctx.Battles.FirstOrDefault(b => b.Id == id);
        }

        public override void Update(Battle item)
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
