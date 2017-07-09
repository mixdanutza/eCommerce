using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class FirstMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_ProductId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductId1",
                table: "Product",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_ProductId1",
                table: "Product",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
