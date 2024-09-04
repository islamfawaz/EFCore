using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_Session3_EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDepartmentView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" Create View EmployeeDepartmentView
                                    With Encryption , SchemaBinding 
                                    As
                                         Select E.Id 'EmployeeID' , E.Name 'EmployeeName' , D.Id 'DepartmentId' , D.Name 'DepartmentName'
                                         from dbo.Employees E left outer join dbo.Departments D
                                    	 on E.DepartmentId = D.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" Drop View EmployeeDepartmentView");
        }
    }
}
