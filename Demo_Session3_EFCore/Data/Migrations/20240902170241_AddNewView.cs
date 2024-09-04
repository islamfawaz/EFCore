using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_Session3_EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"   CREATE VIEW AllEmployees
                                      WITH ENCRYPTION, SCHEMABINDING
                                      AS
                                      SELECT 
                                          E.Name AS EmployeeName, 
                                          E.Id AS EmployeeId
                                      FROM 
                                          dbo.Employees E;");

            
            migrationBuilder.Sql(@" CREATE UNIQUE CLUSTERED INDEX IX_AllEmployees
                                    ON AllEmployees(EmployeeId);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW AllEmployees");
        }
    }
}
