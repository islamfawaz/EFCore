using DataBaseFirst.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst
{
    internal class Program
    {
        static void Main()
        {
            

            using NorthwindContext dbContext = new NorthwindContext();


            #region  Execute Select Statement : FromSqlRow() , FromSqlInterpolated() 

            //var count = 4;


            //var result = dbContext.Categories.FromSqlRaw("select top({0}) * from Categories", count);
            //result = dbContext.Categories.FromSqlInterpolated($"select top({count}) * from Categories");

            //foreach (var category in result)
            //    Console.WriteLine(category.CategoryName); 


            #endregion



            #region Execute Insert Update Delete  Statement : FromSqlRow() , FromSqlInterpolated() 

            //dbContext.Database.ExecuteSqlRaw("Update Categories set CategoryName = 'Beverages' Where CategoryId = 1");

            #endregion



        }
    }
 }
