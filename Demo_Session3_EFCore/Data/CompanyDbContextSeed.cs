using Demo_Session3_EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo_Session3_EFCore.Data
{
    internal static class CompanyDbContextSeed
    {

        public static void Seed(ApplicationDbContext dbContext)
        {
            if (!dbContext.Departments.Any())
            {
                var path = "Data/DataSeed/Departments.json";
                var departmentPath = Path.Combine(AppContext.BaseDirectory, "../../..", path);



                var departmentData = File.ReadAllText(departmentPath);
                var departments = JsonSerializer.Deserialize<List<Department>>(departmentData);

                if (departments != null)
                    foreach (var item in departments)
                        dbContext.Add(item);



            }


            if (!dbContext.Employees.Any())
            {
                var path = "Data/DataSeed/Employees.json";
                var employeesPath = Path.Combine(AppContext.BaseDirectory, "../../..", path);



                var employeesData = File.ReadAllText(employeesPath);
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);

                if (employees != null)
                    foreach (var item in employees)
                        dbContext.Add(item);
            }


            dbContext.SaveChanges();
        }

    }
}
