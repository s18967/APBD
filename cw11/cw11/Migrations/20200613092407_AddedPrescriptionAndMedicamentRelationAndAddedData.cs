using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw11.Migrations
{
    public partial class AddedPrescriptionAndMedicamentRelationAndAddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientIdPatient",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicamentIdMedicament",
                table: "Medicaments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorIdDoctor",
                table: "Doctors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prescription_Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: true),
                    Details = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicaments", x => new { x.IdMedicament, x.IdPrescription });
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: false),
                    IdPatient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "DoctorIdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, null, "test1@wp.pl", "test1", "test1" },
                    { 2, null, "test2@wp.pl", "test2", "test2" },
                    { 3, null, "test3@wp.pl", "test3", "test3" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName", "PatientIdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 13, 11, 24, 6, 950, DateTimeKind.Local).AddTicks(7598), "doctor1", "doctor1", null },
                    { 2, new DateTime(2020, 6, 13, 11, 24, 6, 953, DateTimeKind.Local).AddTicks(1798), "doctor2", "doctor2", null },
                    { 3, new DateTime(2020, 6, 13, 11, 24, 6, 953, DateTimeKind.Local).AddTicks(1833), "doctor3", "doctor3", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientIdPatient",
                table: "Patients",
                column: "PatientIdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_MedicamentIdMedicament",
                table: "Medicaments",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorIdDoctor",
                table: "Doctors",
                column: "DoctorIdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Doctors_DoctorIdDoctor",
                table: "Doctors",
                column: "DoctorIdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicaments_Medicaments_MedicamentIdMedicament",
                table: "Medicaments",
                column: "MedicamentIdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Patients_PatientIdPatient",
                table: "Patients",
                column: "PatientIdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Doctors_DoctorIdDoctor",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicaments_Medicaments_MedicamentIdMedicament",
                table: "Medicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Patients_PatientIdPatient",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Prescription_Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientIdPatient",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Medicaments_MedicamentIdMedicament",
                table: "Medicaments");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorIdDoctor",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PatientIdPatient",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicamentIdMedicament",
                table: "Medicaments");

            migrationBuilder.DropColumn(
                name: "DoctorIdDoctor",
                table: "Doctors");
        }
    }
}
