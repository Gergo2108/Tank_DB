using K9P4EG_HFT_2022231.Repository.Database;
using K9P4EG_HFT_2022231.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Repository
{
    public abstract class GenericRepository<T> : Repo<T> where T : class
    {
        protected TankDbContex ctx;

        public GenericRepository(TankDbContex ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public abstract T Read(int id);
       

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract void Update(T item);
        
    }
}
