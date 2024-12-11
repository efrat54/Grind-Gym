using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grind.Data.Migrations
{
    public partial class MyInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClientsLst",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addressid = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsLst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientsLst_Address_Addressid",
                        column: x => x.Addressid,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainersLst",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    expertise = table.Column<int>(type: "int", nullable: false),
                    monthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addressid = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainersLst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainersLst_Address_Addressid",
                        column: x => x.Addressid,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    hour = table.Column<int>(type: "int", nullable: false),
                    minute = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.id);
                    table.ForeignKey(
                        name: "FK_Time_TrainersLst_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainersLst",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassLst",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    className = table.Column<int>(type: "int", nullable: false),
                    trainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classTimeid = table.Column<int>(type: "int", nullable: false),
                    difficulty = table.Column<int>(type: "int", nullable: false),
                    numOfParticipants = table.Column<int>(type: "int", nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassLst_Time_classTimeid",
                        column: x => x.classTimeid,
                        principalTable: "Time",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassLst_classTimeid",
                table: "ClassLst",
                column: "classTimeid");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsLst_Addressid",
                table: "ClientsLst",
                column: "Addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Time_TrainerId",
                table: "Time",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainersLst_Addressid",
                table: "TrainersLst",
                column: "Addressid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassLst");

            migrationBuilder.DropTable(
                name: "ClientsLst");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "TrainersLst");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
