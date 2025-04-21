using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KnowledgeHubPortal.Data
{
    public class KHPortalDbContextFactory : IDesignTimeDbContextFactory<KHPortalDbContext>
    {
        public KHPortalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KHPortalDbContext>();
            optionsBuilder.UseSqlServer("Data Source=EC2AMAZ-2KE9K2R\\MSSQLSERVER01;Initial Catalog=BrodridgeKHPortalDB2025;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            return new KHPortalDbContext(optionsBuilder.Options);
        }
    }
}