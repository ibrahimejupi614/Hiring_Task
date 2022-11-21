namespace Hiring_Task.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("Server=.\\SQLExpress;Database=hiring_taskdb;Trusted_Connection=true;Encrypt=false");
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<TaskModel> Tasks => Set<TaskModel>();
    }
}
