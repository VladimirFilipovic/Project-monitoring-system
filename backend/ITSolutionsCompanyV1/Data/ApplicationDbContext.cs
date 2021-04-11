using System;
using System.Collections.Generic;
using System.Text;
using ITSolutionsCompanyV1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITSolutionsCompanyV1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //TODO: Seed data
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Demo> Demos { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Documentation> Documentations { get; set; }
        //TODO: refactor model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Blog>()
                 .Property(b => b.Url)
                 .IsRequired();*/
            #region default values
            modelBuilder.Entity<ApplicationUser>()
                 .Property(au => au.AccountIsActive)
                 .HasDefaultValue(true);
            
            modelBuilder.Entity<Demo>()
                .Property(d => d.DateCreated)
                .HasDefaultValue("getdate()");
            
            modelBuilder.Entity<Documentation>()
                .Property(d => d.DateCreated)
                .HasDefaultValue("getdate()");
            
            modelBuilder.Entity<Employee>()
                .Property(e => e.StartDateOfContract)
                .HasDefaultValue("getdate()");
           
            modelBuilder.Entity<Payment>()
                .Property(p => p.Currency)
                .HasDefaultValue("EUR");
           
            modelBuilder.Entity<Request>()
                .Property(r => r.DateSent)
                .HasDefaultValue("getdate()");
           
            modelBuilder.Entity<Request>()
               .Property(r => r.Accepted)
               .HasDefaultValue(false);
            #endregion
            #region relationships
            modelBuilder.Entity<Employee>()
                 .HasMany(e => e.Requests)
                 .WithOne(r => r.Employee);
           
            modelBuilder.Entity<Client>()
                 .HasMany(c => c.Requests)
                 .WithOne(r => r.Client);
            
            modelBuilder.Entity<EmployeeTask>()
             .HasKey(et => new { et.EmployeeId, et.TaskId });
        }

    }
}
