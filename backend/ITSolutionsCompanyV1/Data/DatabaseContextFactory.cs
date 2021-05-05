using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Data.SeedData
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(
                 new ConfigurationBuilder()
                     .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.json"))
                     .AddEnvironmentVariables()
                     .Build()
                     .GetConnectionString("DefaultConnection")
                 ).Options);
            dbContext.Database.Migrate();
            return dbContext;
        }
    }
}
