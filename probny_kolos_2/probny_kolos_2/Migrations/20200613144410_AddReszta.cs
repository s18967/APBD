using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace probny_kolos_2.Migrations
{
    public partial class AddReszta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Pracownicy",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imie",
                table: "Pracownicy",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Zamow_wybory",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false),
                    IdZamowienia = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true),
                    Zamow_wyrobIdWyrobuCukierniczego = table.Column<int>(nullable: true),
                    Zamow_wyrobIdZamowienia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamow_wybory", x => new { x.IdWyrobuCukierniczego, x.IdZamowienia });
                    table.ForeignKey(
                        name: "FK_Zamow_wybory_Zamow_wybory_Zamow_wyrobIdWyrobuCukierniczego_Zamow_wyrobIdZamowienia",
                        columns: x => new { x.Zamow_wyrobIdWyrobuCukierniczego, x.Zamow_wyrobIdZamowienia },
                        principalTable: "Zamow_wybory",
                        principalColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: true),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true),
                    IdKlient = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienia);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamow_wybory_Zamow_wyrobIdWyrobuCukierniczego_Zamow_wyrobIdZamowienia",
                table: "Zamow_wybory",
                columns: new[] { "Zamow_wyrobIdWyrobuCukierniczego", "Zamow_wyrobIdZamowienia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamow_wybory");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Pracownicy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imie",
                table: "Pracownicy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
