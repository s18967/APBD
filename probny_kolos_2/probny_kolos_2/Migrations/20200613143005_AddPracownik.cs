using Microsoft.EntityFrameworkCore.Migrations;

namespace probny_kolos_2.Migrations
{
    public partial class AddPracownik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    PracownikIdPracownik = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                    table.ForeignKey(
                        name: "FK_Pracownicy_Pracownicy_PracownikIdPracownik",
                        column: x => x.PracownikIdPracownik,
                        principalTable: "Pracownicy",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_PracownikIdPracownik",
                table: "Pracownicy",
                column: "PracownikIdPracownik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pracownicy");
        }
    }
}
