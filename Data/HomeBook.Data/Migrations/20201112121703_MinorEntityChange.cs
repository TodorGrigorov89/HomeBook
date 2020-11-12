namespace HomeBook.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MinorEntityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserDocuments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserDocuments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserApartments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserApartments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_IsDeleted",
                table: "UserDocuments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserApartments_IsDeleted",
                table: "UserApartments",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDocuments_IsDeleted",
                table: "UserDocuments");

            migrationBuilder.DropIndex(
                name: "IX_UserApartments_IsDeleted",
                table: "UserApartments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserDocuments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserApartments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserApartments");
        }
    }
}
