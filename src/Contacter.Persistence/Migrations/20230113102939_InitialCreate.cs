using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "nvarchar(max)", nullable: true),
                    AddressCity = table.Column<string>(name: "Address_City", type: "nvarchar(max)", nullable: true),
                    AddressPostalCode = table.Column<string>(name: "Address_PostalCode", type: "nvarchar(max)", nullable: true),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameFirst = table.Column<string>(name: "Name_First", type: "nvarchar(max)", nullable: false),
                    NameLast = table.Column<string>(name: "Name_Last", type: "nvarchar(max)", nullable: false),
                    SocialsEmailAddress = table.Column<string>(name: "Socials_EmailAddress", type: "nvarchar(max)", nullable: true),
                    SocialsTwitter = table.Column<string>(name: "Socials_Twitter", type: "nvarchar(max)", nullable: true),
                    SocialsInstagram = table.Column<string>(name: "Socials_Instagram", type: "nvarchar(max)", nullable: true),
                    SocialsLinkedIn = table.Column<string>(name: "Socials_LinkedIn", type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyId",
                table: "Contacts",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
