using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Session3_EFCore.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly CreationDate { get; set; }
        public int? ManagerID { get; set; }  // Manager of Department 
        public virtual Employee Manager { get; set; } = null!;



        // Many Employee work in department [Many}
        public virtual ICollection<Employee> employees { get; set; } = new HashSet<Employee>();


        public override string ToString()
        {
            var employeesString = employees.Any()
                ? string.Join(", ", employees.Select(e => e.ToString()))
                : "No Employees";

            return $"Id : {Id}\t\t" +
                   $"Name : {Name}\t\t" +
                   $"Creation Date : {CreationDate}\n";
            //$"Employees     : {employeesString}";
        }

    }
}
