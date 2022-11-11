using K9P4EG_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Repository.Database
{
  public  class TankDbContex : DbContext 
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
                entity
                  .HasOne(tank => tank.Country)
                  .WithMany(country => country.Tanks)
                  .HasForeignKey(tank => tank.CountryId)
                  .OnDelete(DeleteBehavior.Cascade);
                    
            });

            modelBuilder.Entity<Tank>(entity =>
            {
                entity
                  .HasOne(tank => tank.Battle)
                  .WithMany(battle => battle.Tanks)
                  .HasForeignKey(tank => tank.BattleId)
                  .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Country>(entity => 
            {
                entity
                 .HasMany(country => country.Tanks)
                .WithOne(tank => tank.Country)
                .HasForeignKey(country => country.Id)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Battle>(entity =>
            {
                entity
                 .HasMany(battle => battle.Tanks)
                 .WithOne(tank => tank.Battle)
                 .HasForeignKey(battle => battle.Id)
                 .OnDelete(DeleteBehavior.Cascade);
                
            });


            Country Russia = new Country() { Id = 1, Name = "Russia" };
            Country Chine = new Country() { Id = 2, Name = "China" };

            Battle b1 = new Battle() { Name = "AsiaWar", Id = 1,};

            Tank t1 = new Tank() { Id = 1, CountryId = Russia.Id, GunSize = 120, Weight = 12, Model = "T-72", BattleId = b1.Id };
            Tank t2 = new Tank() { Id = 2, CountryId = Chine.Id, GunSize = 100, Weight = 10, Model = "Type-1", BattleId = b1.Id };

            modelBuilder.Entity<Country>().HasData(Russia, Chine);
            modelBuilder.Entity<Battle>().HasData(b1);
            modelBuilder.Entity<Tank>().HasData(t1, t2);
        }

    }
}
