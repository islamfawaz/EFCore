using Demo_Session3_EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo_Session3_EFCore
{
    internal class Program
    {
        static void Main()
        {
            using ApplicationDbContext dbContext = new ApplicationDbContext();

            CompanyDbContextSeed.Seed(dbContext); // seed data


            #region Navigation Property

            //// navigation property in default will be not loaded 

            //var emp = dbContext.Employees.Where(E => E.Id == 1).FirstOrDefault();
            //if (emp != null)

            //    Console.WriteLine($"{emp} \n=====> {emp.Department}"); 
            #endregion


            #region EXplicit Loading

            //var emp = dbContext.Employees.Where(E => E.Id == 1).FirstOrDefault();
            //if (emp != null)
            //{
            //    dbContext.Entry(emp).Reference(e => e.Department).Load(); // Loading Explicitly
            //    Console.WriteLine($"{emp} \n=====\n\n{emp.Department}");
            //}



            //var dep = dbContext.Departments.Where(d => d.Id == 1).FirstOrDefault();
            //if (dep != null)
            //{
            //    dbContext.Entry(dep).Collection(d => d.employees).Load(); // Loading Explicitly
            //    Console.WriteLine($"{dep} \n=====\n\n");

            //    foreach (var empp in dep.employees)
            //        Console.WriteLine($"{empp}");
            //}

            #endregion


            #region Eager Loading


            //var emp = dbContext.Employees.Include(e => e.Department).Where(E => E.Id == 1).FirstOrDefault();

            //if (emp != null)
            //{
            //    Console.WriteLine($"{emp} \n=====>\n\n{emp.Department}");
            //}



            //var dep = dbContext.Departments.Include(d => d.employees).Where(d => d.Id == 1).FirstOrDefault();
            //if (dep != null)
            //{
            //    //dbContext.Entry(dep).Collection(d => d.employees).Load(); // Loading Explicitly
            //    Console.WriteLine($"{dep} \n=====\n\n");

            //    foreach (var emp1 in dep.employees)
            //        Console.WriteLine($"{emp1}");
            //}


            #endregion


            #region Lazy Loading

            //var dep = dbContext.Departments.Where(d => d.Id == 1).FirstOrDefault();

            //if (dep != null)
            //{

            //    Console.WriteLine($"{dep} \n=====\n\n");

            //    foreach (var emp1 in dep.employees)
            //        Console.WriteLine($"{emp1}");
            //}

            #endregion


            #region Linq - Join Operator [Join - GroupJoin]


            #region Inner Join

            //var result = from d in dbContext.Departments
            //             join e in dbContext.Employees
            //             on d.Id equals e.DepartmentId
            //             select new
            //             {
            //                 //EmpId = e.Id,
            //                 EmpName = e.Name,
            //                 //DeptID = d.Id,
            //                 DeptName = d.Name,
            //             };

            //result = dbContext.Departments.Join(dbContext.Employees,
            //                                   d => d.Id,
            //                                   e => e.DepartmentId,
            //                                   (d, e) => new
            //                                   {
            //                                       //EmpId = e.Id,
            //                                       EmpName = e.Name,
            //                                       //DeptID = d.Id,
            //                                       DeptName = d.Name,
            //                                   });

            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion



            #region Group join

            #region Ex 1 
            //var result = dbContext.Departments.GroupJoin(dbContext.Employees,
            //                                   d => d.Id,
            //                                   e => e.DepartmentId,
            //                                   (department, employees) => new
            //                                   {
            //                                       department,
            //                                       employees
            //                                   }).ToList().Where(x => x.employees.Count() > 0);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.department);
            //    foreach (var emps in item.employees)
            //        Console.WriteLine(emps);
            //} 
            #endregion


            #region Ex 2

            //var result = dbContext.Employees.GroupJoin(dbContext.Departments,
            //                                   e => e.DepartmentId,
            //                                   d => d.Id,
            //                                   (employee, department) => new
            //                                   {
            //                                       employee,
            //                                       department

            //                                   }).ToList().Where(x => x.employee.DepartmentId != null);

            //foreach (var item in result)
            //{

            //    Console.WriteLine(item.employee);
            //}

            #endregion

            #endregion


            #region Left Outer Join

            //var result = dbContext.Departments.GroupJoin(dbContext.Employees,
            //                                   d => d.Id,
            //                                   e => e.DepartmentId,
            //                                   (department, employees) => new
            //                                   {
            //                                       department,
            //                                       employees = employees.DefaultIfEmpty()
            //                                   }).SelectMany(x => x.employees, (x, employee) => new { x.department, employee });


            //foreach (var item in result)
            //    Console.WriteLine($"{item.department.Name} ====>  {item.employee?.Name ?? "No Employee"}");

            #endregion


            #region Cross Join 

            //var result = dbContext.Employees.SelectMany(e => dbContext.Departments
            //                                                      .Select(d => new
            //                                                      {
            //                                                          employee = e,
            //                                                          department = d
            //                                                      })).ToList();


            //foreach (var item in result)
            //    Console.WriteLine($"emp : {item.employee.Name} ====>  Dep :  {item.department.Name}");

            #endregion


            #endregion


            #region View Mapping

            //var result = dbContext.EmployeeDepartmentsView;

            //foreach(var Emp in result)
            //    Console.WriteLine($"EmpName : {Emp.EmployeeName} ===> DepName : {Emp?.DepartmentName ?? "Null"}");

            //var result = dbContext.AllEmployees;

            //foreach (var item in result) 
            //    Console.WriteLine($"name : {item.EmployeeName} ===== id : {item.EmployeeID}");


            #endregion



        }
    }
}
