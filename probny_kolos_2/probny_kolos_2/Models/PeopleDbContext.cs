using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probny_kolos_2.Models
{
    public class PeopleDbContext : DbContext
    {
        public DbSet<Klient> Klients { get; set; }
        public DbSet<WyrobCukierniczy> WyrobyCukiernicze { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Zamow_wyrob> Zamow_wyroby { get; set; }



        public PeopleDbContext() { }
        public PeopleDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
   
            var dictKlient = new List<Klient>();
            dictKlient.Add(new Klient { IdKlient = 1, Imie = "test1", Nazwisko = "test1"});
            dictKlient.Add(new Klient { IdKlient = 2, Imie = "test2", Nazwisko = "test2"});
            dictKlient.Add(new Klient { IdKlient = 3, Imie = "test3", Nazwisko = "test3"});

            modelBuilder.Entity<Klient>().HasData(dictKlient);

            var dictPracownik = new List<Pracownik>();
            dictPracownik.Add(new Pracownik { IdPracownik = 1, Imie = "pracownik1", Nazwisko = "pracownik1" });
            dictPracownik.Add(new Pracownik { IdPracownik = 2, Imie = "pracownik2", Nazwisko = "pracownik2" });
            dictPracownik.Add(new Pracownik { IdPracownik = 3, Imie = "pracownik3", Nazwisko = "pracownik3" });

            modelBuilder.Entity<Pracownik>().HasData(dictPracownik);

            var dictWyrob = new List<WyrobCukierniczy>();
            dictWyrob.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 1, Nazwa = "wyrob1", CenaZaSzt = 1.0f, Typ = "ciasto"});
            dictWyrob.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 2, Nazwa = "wyrob2", CenaZaSzt = 2.0f, Typ = "pączek"});
            dictWyrob.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 3, Nazwa = "wyrob3", CenaZaSzt = 3.0f, Typ = "obważanek"});

            modelBuilder.Entity<WyrobCukierniczy>().HasData(dictWyrob);

            var dictZamowienie = new List<Zamowienie>();
            dictZamowienie.Add(new Zamowienie { IdZamowienia = 1, DataPrzyjecia = DateTime.Now, IdKlient = 1, IdPracownik = 1});
            dictZamowienie.Add(new Zamowienie { IdZamowienia = 2, DataPrzyjecia = DateTime.Now, IdKlient = 3, IdPracownik = 2});
            dictZamowienie.Add(new Zamowienie { IdZamowienia = 3, DataPrzyjecia = DateTime.Now, IdKlient = 3, IdPracownik = 2});

            modelBuilder.Entity<Zamowienie>().HasData(dictZamowienie);

            var dictZamowWyrob = new List<Zamow_wyrob>();
            dictZamowWyrob.Add(new Zamow_wyrob { IdWyrobuCukierniczego = 1, IdZamowienia = 1, Ilosc = 5});
            dictZamowWyrob.Add(new Zamow_wyrob { IdWyrobuCukierniczego = 2, IdZamowienia = 2, Ilosc = 3});
            dictZamowWyrob.Add(new Zamow_wyrob { IdWyrobuCukierniczego = 3, IdZamowienia = 1, Ilosc = 7});

            modelBuilder.Entity<Zamow_wyrob>().HasData(dictZamowWyrob);

            modelBuilder.Entity<Zamow_wyrob>()
                        .HasKey(zw => new { zw.IdWyrobuCukierniczego, zw.IdZamowienia });

        }

    }
}
