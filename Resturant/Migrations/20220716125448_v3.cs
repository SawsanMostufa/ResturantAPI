using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddtionalMeals_requests_RequestId",
                table: "AddtionalMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTypes_requests_RequestId",
                table: "MealTypes");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "MealTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "AddtionalMeals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddtionalMeals_requests_RequestId",
                table: "AddtionalMeals",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTypes_requests_RequestId",
                table: "MealTypes",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddtionalMeals_requests_RequestId",
                table: "AddtionalMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTypes_requests_RequestId",
                table: "MealTypes");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "MealTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "AddtionalMeals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AddtionalMeals_requests_RequestId",
                table: "AddtionalMeals",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTypes_requests_RequestId",
                table: "MealTypes",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
