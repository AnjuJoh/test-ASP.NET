using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Event.Migrations
{
    /// <inheritdoc />
    public partial class Initt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.CreateTable(
                name: "Registration_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    BusinessName = table.Column<string>(type: "longtext", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    ModeOfBusiness = table.Column<string>(type: "longtext", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration_table", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration_table");

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BusinessName = table.Column<string>(type: "longtext", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    ModeOfBusiness = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    ResetToken = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }
    }
}
