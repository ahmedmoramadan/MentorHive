using Microsoft.EntityFrameworkCore;
using MVCTASK.Models;

namespace MVCTASK.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Instractore> instractores { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CrsReselt> crsReselts { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        public DbSet<Department> departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.
                UseSqlServer("Data Source=.;Initial Catalog=TaskITIDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }
    }
}
