using Demo_Session3_EFCore.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Session3_EFCore.Data.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> employee)
        {
            employee.Property(e => e.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

            employee.Property(e => e.Address)
                    .HasDefaultValue("Cairo");

            employee.Property(e => e.Salary)
                    .HasColumnType("decimal( 12,2 )");


            // Any Employee can be Manager to department or not 
            employee.HasOne<Department>()
                    .WithOne(d => d.Manager)
                    .HasForeignKey<Department>(d => d.ManagerID)
                    .OnDelete(DeleteBehavior.SetNull);


            employee.OwnsOne(e => e.AddressDetails, Ad => Ad.WithOwner());

        }
    }
}
