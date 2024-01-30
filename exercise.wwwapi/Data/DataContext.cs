using exercise.wwwapi.Models;
using Microsoft.EntityFrameworkCore;


namespace exercise.wwwapi.Data
{   
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
