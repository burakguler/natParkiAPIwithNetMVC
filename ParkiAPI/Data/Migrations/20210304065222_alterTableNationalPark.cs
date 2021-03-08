using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkiAPI.Migrations
{
    public partial class alterTableNationalPark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "NationalPark",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "NationalPark",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "listingDate",
                table: "NationalPark",
                newName: "ListingDate");

            migrationBuilder.RenameColumn(
                name: "area",
                table: "NationalPark",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "NationalPark",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "NationalPark",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "NationalPark",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "ListingDate",
                table: "NationalPark",
                newName: "listingDate");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "NationalPark",
                newName: "area");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "NationalPark",
                newName: "created");
        }
    }
}
