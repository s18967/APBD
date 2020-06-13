using Microsoft.EntityFrameworkCore.Migrations;

namespace probny_kolos_2.Migrations
{
    public partial class AddWyrob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlientIdKlient",
                table: "Klients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WyrobyCukiernicze",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 200, nullable: true),
                    CenaZaSzt = table.Column<float>(nullable: false),
                    Typ = table.Column<string>(maxLength: 40, nullable: true),
                    WyrobCukierniczyIdWyrobuCukierniczego = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobyCukiernicze", x => x.IdWyrobuCukierniczego);
                    table.ForeignKey(
                        name: "FK_WyrobyCukiernicze_WyrobyCukiernicze_WyrobCukierniczyIdWyrobuCukierniczego",
                        column: x => x.WyrobCukierniczyIdWyrobuCukierniczego,
                        principalTable: "WyrobyCukiernicze",
                        principalColumn: "IdWyrobuCukierniczego",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klients_KlientIdKlient",
                table: "Klients",
                column: "KlientIdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_WyrobyCukiernicze_WyrobCukierniczyIdWyrobuCukierniczego",
                table: "WyrobyCukiernicze",
                column: "WyrobCukierniczyIdWyrobuCukierniczego");

            migrationBuilder.AddForeignKey(
                name: "FK_Klients_Klients_KlientIdKlient",
                table: "Klients",
                column: "KlientIdKlient",
                principalTable: "Klients",
                principalColumn: "IdKlient",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klients_Klients_KlientIdKlient",
                table: "Klients");

            migrationBuilder.DropTable(
                name: "WyrobyCukiernicze");

            migrationBuilder.DropIndex(
                name: "IX_Klients_KlientIdKlient",
                table: "Klients");

            migrationBuilder.DropColumn(
                name: "KlientIdKlient",
                table: "Klients");
        }
    }
}
