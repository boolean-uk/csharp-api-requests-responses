using Microsoft.EntityFrameworkCore;

using exercise.wwwapi.Models;

class StudentDb : DbContext
{
    public StudentDb(DbContextOptions<StudentDb> options)
    : base(options) { }

    public DbSet<Student> Students => Set<Student>();
}
