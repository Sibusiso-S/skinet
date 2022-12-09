using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class PictureURLUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemOrdered_ProductUrl",
                table: "OrderItems");

            migrationBuilder.AlterColumn<string>(
                name: "ItemOrdered_ProductName",
                table: "OrderItems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "OrderDate",
                table: "Order",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "ItemOrdered_ProductName",
                table: "OrderItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ItemOrdered_ProductUrl",
                table: "OrderItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderDate",
                table: "Order",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");
        }
    }
}
