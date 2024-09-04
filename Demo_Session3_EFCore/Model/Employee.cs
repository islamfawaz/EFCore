using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Session3_EFCore.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; } = null!;
        public Address AddressDetails { get; set; } = null!;




        public override string ToString()
        {
            return $"Id : {Id}\t\t" +
                   $"Name : {Name}\t\t" +
                   $"Age : {Age?.ToString() ?? "NA"}\t\t" +
                   $"Address : {Address ?? "NA"}\t\t" +
                   $"Salary : {Salary}\t\t" +
                   $"DepartmentId : {DepartmentId?.ToString() ?? "NA"}\n";

        }

    }
}
