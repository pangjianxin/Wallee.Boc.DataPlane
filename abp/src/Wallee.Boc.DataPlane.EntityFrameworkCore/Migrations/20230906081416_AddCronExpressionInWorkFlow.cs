using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class AddCronExpressionInWorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CronExpression",
                table: "AppTDcmpWorkFlows",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CronExpression",
                table: "AppTDcmpWorkFlows");
        }
    }
}
