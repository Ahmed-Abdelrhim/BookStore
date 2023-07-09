using Microsoft.EntityFrameworkCore;
using Core1.Models;
namespace Core1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Item> items {get; set;}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Electronics", },
                new Category() { Id = 2, Name = "PCs", },
                new Category() { Id = 3, Name = "Washers", },
                new Category() { Id = 4, Name = "Devices", },
                new Category() { Id = 5, Name = "Mobiles", }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
