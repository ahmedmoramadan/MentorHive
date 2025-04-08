namespace MVCTASK.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Instructor> instructors { get; set; }
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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CrsReselt>().HasKey(c => new { c.TraineeId, c.CourseId });
        }

    }
}
