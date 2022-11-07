using K9P4EG_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Repository.Database
{
    class TankDbContex : DbContext 
    {
        public virtual DbSet<Tank> Tanks { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Battle> Battles { get; set; }

        public TankDbContex()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tank>(entity =>
            {
              
                
            });

            

        }

    }
}
