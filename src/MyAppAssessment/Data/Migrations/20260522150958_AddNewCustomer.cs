using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAppAssessment.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 var sql = File.ReadAllText("sql/2026-05-22-AddNewCustomer.sql");

            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

 var sql = File.ReadAllText("sql/2026-05-22-DeleteNewCustomer.sql");

            migrationBuilder.Sql(sql);
        }
    }
}
