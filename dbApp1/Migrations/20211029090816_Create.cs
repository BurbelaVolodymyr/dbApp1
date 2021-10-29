using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dbApp1.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CardID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WorkerNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WORKER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CardID = table.Column<int>(type: "int", nullable: false),
                    CodeID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Wage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WORKER_To_COMPANY",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RESORT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESORT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESORT_To_COUNTRY",
                        column: x => x.CountryId,
                        principalTable: "COUNTRY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ORDERING",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    TicketNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERING", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDERING_To_CLIENT",
                        column: x => x.ClientId,
                        principalTable: "CLIENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ORDERING_To_WORKER",
                        column: x => x.WorkerId,
                        principalTable: "WORKER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HOTEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResortId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StarsNumber = table.Column<int>(type: "int", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Safe = table.Column<bool>(type: "bit", nullable: true),
                    Conditioner = table.Column<bool>(type: "bit", nullable: true),
                    WiFi = table.Column<bool>(type: "bit", nullable: true),
                    Bed = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MiniBar = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOTEL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HOTEL_To_RESORT",
                        column: x => x.ResortId,
                        principalTable: "RESORT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TICKET",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderingId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    TimeDeparture = table.Column<DateTime>(type: "date", nullable: true),
                    TimeArrival = table.Column<DateTime>(type: "date", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    TouristNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICKET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TICKET_To_HOTEL",
                        column: x => x.HotelId,
                        principalTable: "HOTEL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TICKET_To_ORDERING",
                        column: x => x.OrderingId,
                        principalTable: "ORDERING",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CARE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARE_To_TICKET",
                        column: x => x.TicketId,
                        principalTable: "TICKET",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARE_TicketId",
                table: "CARE",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "UQ__CLIENT__DDA1796C7F277D7D",
                table: "CLIENT",
                columns: new[] { "CardID", "PhoneNumber" },
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_COUNTRY_Name",
                table: "COUNTRY",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HOTEL_ResortId",
                table: "HOTEL",
                column: "ResortId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERING_ClientId",
                table: "ORDERING",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERING_WorkerId",
                table: "ORDERING",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_RESORT_CountryId",
                table: "RESORT",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UQ_RESORT_Name",
                table: "RESORT",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TICKET_HotelId",
                table: "TICKET",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_TICKET_OrderingId",
                table: "TICKET",
                column: "OrderingId");

            migrationBuilder.CreateIndex(
                name: "IX_WORKER_CompanyId",
                table: "WORKER",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UQ__WORKER__2116D40233C00CD6",
                table: "WORKER",
                columns: new[] { "CardID", "CodeID", "PhoneNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARE");

            migrationBuilder.DropTable(
                name: "TICKET");

            migrationBuilder.DropTable(
                name: "HOTEL");

            migrationBuilder.DropTable(
                name: "ORDERING");

            migrationBuilder.DropTable(
                name: "RESORT");

            migrationBuilder.DropTable(
                name: "CLIENT");

            migrationBuilder.DropTable(
                name: "WORKER");

            migrationBuilder.DropTable(
                name: "COUNTRY");

            migrationBuilder.DropTable(
                name: "COMPANY");
        }
    }
}
