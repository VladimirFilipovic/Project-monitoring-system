using System;
using System.Collections.Generic;
using System.Text;
using ITSolutionsCompanyV1.Data.SeedData.Entities;
using ITSolutionsCompanyV1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITSolutionsCompanyV1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
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
        internal virtual DbSet<SeedingEntry> SeedingEntries { get; set; }
        public DbSet<Documentation> Documentation { get; set; }
        //TODO: refactor model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region default values
            modelBuilder.Entity<ApplicationUser>()
                 .Property(au => au.AccountIsActive)
                 .HasDefaultValue(true);
            
            modelBuilder.Entity<Demo>()
                .Property(d => d.DateCreated)
                .HasDefaultValueSql("getdate()");
            
            modelBuilder.Entity<Documentation>()
                .Property(d => d.DateCreated)
                .HasDefaultValueSql("getdate()");
            
            modelBuilder.Entity<Employee>()
                .Property(e => e.StartDateOfContract)
                .HasDefaultValueSql("getdate()");
           
            modelBuilder.Entity<Payment>()
                .Property(p => p.Currency)
                .HasDefaultValue("EUR");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Date)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Request>()
                .Property(r => r.DateSent)
                .HasDefaultValueSql("getdate()");
           
            modelBuilder.Entity<Request>()
               .Property(r => r.Accepted)
               .HasDefaultValue(false);

            modelBuilder.Entity<SeedingEntry>()
                .HasKey(s => s.Name);

            modelBuilder.Entity<Project>()
                .Property(p => p.IsCompleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Task>()
                .Property(t => t.Completed)
                .HasDefaultValue(false);

            modelBuilder.Entity<EmployeeProject>()
                .Property(ep => ep.Deleted)
                .HasDefaultValue(false);
            #endregion
            #region constraints
            /*modelBuilder.Entity<ApplicationUser>()
                .Property(au => au.UserImage)
                .HasMaxLength(10485760); //10mb*/

            modelBuilder.Entity<ApplicationRole>()
                .Property(ar => ar.Description)
                .HasMaxLength(600);

            modelBuilder.Entity<Client>()
                .Property(c => c.CompanyName)
                .HasMaxLength(300);
            modelBuilder.Entity<Client>()
                .Property(c => c.Pib)
                .HasMaxLength(8);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Demo>()
                .Property(d => d.Name)
                .HasMaxLength(200);

            modelBuilder.Entity<Documentation>()
                .Property(d => d.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<Documentation>()
               .Property(d => d.Version)
               .HasMaxLength(30);

            modelBuilder.Entity<Request>()
                .Property(r => r.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Project>()
                .Property(p => p.Name)
                .HasMaxLength(200);

            modelBuilder.Entity<EmployeeProject>()
               .Property(ep => ep.RoleOnProject)
               .HasMaxLength(200);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
               .Property(p => p.Amount)
               .HasMaxLength(10);


            modelBuilder.Entity<Task>()
                .Property(t => t.Name)
                .HasMaxLength(300);
            #endregion
            #region relationships
            /*modelBuilder.Entity<Employee>()
                 .HasMany(e => e.Requests)
                 .WithOne(r => r.Employee);
           
            modelBuilder.Entity<Client>()
                 .HasMany(c => c.Requests)
                 .WithOne(r => r.Client);*/

            modelBuilder.Entity<EmployeeTask>()
             .HasKey(et => new { et.EmployeeId, et.TaskId });

            modelBuilder.Entity<EmployeeTask>()
                  .HasOne(et => et.Employee)
                  .WithMany(e => e.EmployeeTasks);

            modelBuilder.Entity<EmployeeTask>()
                  .HasOne(et => et.Task)
                  .WithMany(t => t.EmployeeTasks);

            modelBuilder.Entity<EmployeeProject>()
               .HasKey(ep => new {ep.EmployeeId, ep.ProjectId});

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects);
            #endregion
        }
    }
}
