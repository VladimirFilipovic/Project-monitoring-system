using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static void AddEmployeesDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    x =>
                    {
                        x.MigrationsHistoryTable("__EFMigrationsHistory");
                        x.MigrationsAssembly(typeof(DbContextExtensions).Assembly.GetName().Name);
                    }
                );
            });
        }

        public static void ExecuteSqlScripts(this IApplicationBuilder app, IConfiguration configuration, string typeOfScript)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();

                    var assembly = typeof(DbContextExtensions).Assembly;
                    var files = assembly.GetManifestResourceNames();

                    var executedSeedings = context.SeedingEntries.ToArray();
                    var filePrefix = "";
                    if (typeOfScript == "Triggers")
                    {
                        filePrefix = $"{assembly.GetName().Name}.Data.SqlTriggers.";
                    }
                    else if (typeOfScript == "SeedData")
                    {
                        filePrefix = $"{assembly.GetName().Name}.Data.SeedData.SeedScripts.";
                    }
                    else
                    {
                        throw new Exception("TypeOfScript must be Triggers or SeedData");
                    }
                    foreach (var file in files.Where(f => f.StartsWith(filePrefix) && f.EndsWith(".sql"))
                                              .Select(f => new
                                              {
                                                  PhysicalFile = f,
                                                  LogicalFile = f.Replace(filePrefix, String.Empty)
                                              })
                                              .OrderBy(f => f.LogicalFile))
                    {
                        if (executedSeedings.Any(e => e.Name == file.LogicalFile))
                            continue;

                        string command = string.Empty;
                        using (Stream stream = assembly.GetManifestResourceStream(file.PhysicalFile))
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                command = reader.ReadToEnd();
                            }
                        }

                        if (String.IsNullOrWhiteSpace(command))
                            continue;

                        using (var transaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                context.Database.ExecuteSqlRaw(command);
                                context.SeedingEntries.Add(new SeedData.Entities.SeedingEntry() { Name = file.LogicalFile });
                                context.SaveChanges();
                                transaction.Commit();
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }

                    }
                }
            }
        }
        public static string AddTriggers()
        {
           var assembly = typeof(DbContextExtensions).Assembly;
           var files2 = assembly.GetManifestResourceNames();

                    var filePrefix = $"{assembly.GetName().Name}.Data.SqlTriggers.";
                    foreach (var file in files2.Where(f => f.StartsWith(filePrefix) && f.EndsWith(".sql"))
                                              .Select(f => new
                                              {
                                                  PhysicalFile = f,
                                                  LogicalFile = f.Replace(filePrefix, String.Empty)
                                              })
                                              .OrderBy(f => f.LogicalFile))
                    {

                        string command = string.Empty;
                        using (Stream stream = assembly.GetManifestResourceStream(file.PhysicalFile))
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                command = reader.ReadToEnd();
                            }
                        }


                         if (String.IsNullOrWhiteSpace(command))
                            continue;

                         return command;
                    }
            return "";
        }
    }

}
