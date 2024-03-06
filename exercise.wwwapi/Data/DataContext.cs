using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>().Navigation(x => x.Passengers).AutoInclude();

            //modelBuilder.Entity<Motorbike>().HasData(
                //new Motorbike { Id = 1, Make = "KTM", Model = "390 Adventure" });
        }

        public DbSet<Student> Students { get; set; }
        //public DbSet<Motorbike> Motorbikes { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
