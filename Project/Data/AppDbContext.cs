using Microsoft.EntityFrameworkCore;
using Project.Models; // Import namespace chứa model News

namespace Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<News> News { get; set; } // DbSet ánh xạ đến bảng News
        public DbSet<Customer> Customers { get; set; }
        public DbSet<NewsList> NewsLists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<News>().ToTable("news"); // Đảm bảo ánh xạ đúng bảng PostgreSQL
        }
    }
}
