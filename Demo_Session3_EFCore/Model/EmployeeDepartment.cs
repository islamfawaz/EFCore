using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Session3_EFCore.Model
{
    
    public class EmployeeDepartment
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
