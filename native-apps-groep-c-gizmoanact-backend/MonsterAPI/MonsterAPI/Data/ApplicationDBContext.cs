using MonsterAPI.Model.Model_EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MonsterAPI.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {

      //  public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artisten { get; set; }
        public DbSet<Liedje> Liedjes { get; set; }
        

     
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void AddConfiguration(ModelBuilder mb)
        {

            mb.Entity<Liedje>().HasKey(l => l.ID);
            mb.Entity<Liedje>().HasOne(l => l.artist).WithMany();

            mb.Entity<Artist>().HasKey(a => a.ID);
            

        }

      

        
    }
}
