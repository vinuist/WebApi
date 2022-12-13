using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new () { Id = 1,Name="Elektronik"},
                new () { Id = 2,Name="Beyaz Eşya"}
            });

            modelBuilder.Entity<Products>().Property(x=>x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Products>().HasData(new Products[]
            {
                new(){Id=1,Name="Bilgisayar",CreatedDate=DateTime.Now.AddDays(-3),Price=15000,Stock=500,CategoryId=1},
                new(){Id=2,Name="Telefon",CreatedDate=DateTime.Now.AddDays(-30),Price=10000,Stock=502,CategoryId=1},
                new(){Id=3,Name="Klavye",CreatedDate=DateTime.Now.AddDays(-60),Price=545,Stock=1050, CategoryId = 1}
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
