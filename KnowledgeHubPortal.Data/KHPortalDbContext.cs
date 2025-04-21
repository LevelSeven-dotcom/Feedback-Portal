using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.Data
{
    public class KHPortalDbContext : DbContext
    {
        public KHPortalDbContext(DbContextOptions<KHPortalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Catagory> catagories = new List<Catagory>()
            {
                new Catagory{Id=111, Name = "Sports", Description="Sports related articles" },
                new Catagory{Id=222, Name = "Education", Description="Education related articles" },
                new Catagory{Id=333, Name = ".Net", Description=".Net related articles" },
                new Catagory{Id=444, Name = "MVC", Description="MVC related articles" },
                new Catagory{Id=555, Name = "AI", Description="AI related articles" }
            };
            modelBuilder.Entity<Catagory>().HasData(catagories);
        }

        //map the tables
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
