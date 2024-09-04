using Demo_Session3_EFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Session3_EFCore.Data
{
    internal class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = . ; Database = CompanyG02 ; Trusted_Connection = true ; TrustServerCertificate = true");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<AllEmployees>().ToView("AllEmployees").HasNoKey();
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartmentsView { get; set; }
        public DbSet<AllEmployees> AllEmployees { get; set; }

    }
}
