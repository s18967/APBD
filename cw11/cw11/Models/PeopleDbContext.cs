using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class PeopleDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public PeopleDbContext() { }
        public PeopleDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dictDoctor = new List<Doctor>();
            dictDoctor.Add(new Doctor { IdDoctor = 1, FirstName = "test1", LastName = "test1", Email = "test1@wp.pl"});
            dictDoctor.Add(new Doctor { IdDoctor = 2, FirstName = "test2", LastName = "test2", Email = "test2@wp.pl" });
            dictDoctor.Add(new Doctor { IdDoctor = 3, FirstName = "test3", LastName = "test3", Email = "test3@wp.pl" });

            modelBuilder.Entity<Doctor>().HasData(dictDoctor);

            var dictPatient = new List<Patient>();
            dictPatient.Add(new Patient { IdPatient = 1, FirstName = "doctor1", LastName = "doctor1", BirthDate = DateTime.Now });
            dictPatient.Add(new Patient { IdPatient = 2, FirstName = "doctor2", LastName = "doctor2", BirthDate = DateTime.Now });
            dictPatient.Add(new Patient { IdPatient = 3, FirstName = "doctor3", LastName = "doctor3", BirthDate = DateTime.Now });

            modelBuilder.Entity<Patient>().HasData(dictPatient);

            // ... i tak dalej dla każdej klasy

            // tworzenie wielu PK dla klasy asocjacyjnej
            modelBuilder.Entity<Prescription_Medicament>().HasKey(pm => new { pm.IdMedicament, pm.IdPrescription});


        }


    }
}
