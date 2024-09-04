using Demo_Session3_EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Session3_EFCore.Data.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> department)
        {


            department.Property(d => d.Id)
                      .UseIdentityColumn(1, 1);

            department.Property(d => d.Name)
                      .HasColumnType("varchar")
                      .HasMaxLength(50);

            department.Property(d => d.CreationDate)
                      .HasColumnType("date")
                      .HasDefaultValueSql("GETDATE()");

            // Many Employees Works in one Department
            department.HasMany(d => d.employees)
                      .WithOne(e => e.Department)
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.SetNull);

        }

       
    }
}
