using Microsoft.EntityFrameworkCore;
using Core1.Models;
using Core1.Data;
namespace Core1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // public DbSet<Item> items {get; set;}

        // public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Languages> Languages { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CategoryModel>().HasData(
        //        new CategoryModel() { Id = 1, Name = "Electronics", },
        //        new CategoryModel() { Id = 2, Name = "PCs", },
        //        new CategoryModel() { Id = 3, Name = "Washers", },
        //        new CategoryModel() { Id = 4, Name = "Devices", },
        //        new CategoryModel() { Id = 5, Name = "Mobiles", }
        //        );
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
