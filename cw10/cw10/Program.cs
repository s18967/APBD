using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using cw10.Models;

namespace cw10
{
    class Program
    {
        public static void Main(string[] args)
        {

            //EntityFramework Core
            //Database first
            //Code first

            //QueryExamples();
            //UpdateExamples();
            //RemoveExamples();
            //InsertExamples();

        }

        public static void QueryExamples()
        {
            var db = new SampleDbContext();

            //1. SELECT * FROM Doctor;
            //var res = db.Doctor.ToList();

            //var res = db.Doctor
            //          .Where(d => d.FirstName.StartsWith("J"))
            //          .OrderBy(d => d.LastName)
            //          .ThenBy(d => d.FirstName)
            //          .ToList();

            //2. Lazy loading + Proxies
            //   Eager loading
            //   ToList(), First(), FirstOrDefault(), Single, SingleOrDefault()
            //IQueryable<T>
            //var res = db.Doctor
            //            .Include(d => d.Prescription)
            //            .ToList(); // 1 sql

            ////N+1 problem
            //foreach(var d in res)
            //{
            //    if (d.Prescription.Count() > 1) //N sql
            //    {
            //        //..
            //    }
            //}

            //var res = db.Doctor.OrderBy(d => d.LastName);
            //var res2 = res.Where(d => d.LastName == "Kowalski");

            //var res = db.Doctor
            //          .GroupBy(d => d.FirstName)
            //          .Select(d => new
            //          {
            //              Imie = d.Key,
            //              LiczbaDoktorow = d.Count()
            //          }).ToList();



        }
    
        public static void UpdateExamples()
        {
            var db = new SampleDbContext();

            //UPDATE - Change tracking
            //var d1 = db.Doctor.First();
            //d1.LastName = "Zmiana1";
            //d1.FirstName = "AA";
            ////...
            //db.SaveChanges(); //...

            //IdDoctor=5 -> LastName='Kwiatkowski'
            var d1 = new Doctor
            {
                IdDoctor=5,
                LastName="Kwiatkowski"
            };
            db.Attach(d1); // d1 znajduje sie pod system sledzenie zmian
                           // unchanged
                           //db.Add(d1);
            //db.Entry(d1).Property("LastName").IsModified = true;
            //db.Entry(d1).State = EntityState.Modified;

            db.SaveChanges();

        }
    
        public static void RemoveExamples()
        {
            var db = new SampleDbContext();

            //var d = db.Doctor.OrderByDescending(d => d.IdDoctor).First();
            //db.Doctor.Remove(d);

            var d = new Doctor
            {
                IdDoctor=6
            };
            db.Attach(d);
            db.Remove(d);
            //db.Entry(d).State = EntityState.Deleted;

            db.SaveChanges();

        }//"Data Source=localhost;Initial Catalog=SampleDb;User ID=bd;Password=password1"
        //Microsoft.EntityFrameworkCore.SqlServer

        public static void InsertExamples()
        {
            var db = new SampleDbContext();

            var p = new Prescription()
            {
                Date = DateTime.Now,
                DueDate = DateTime.Now,
                IdPatient = 2
            };
            var set = new HashSet<Prescription> { p };

            var d = new Doctor
            {
                FirstName="AAA",
                LastName="BBB",
                Email="AAA@wp.pl",
                Prescription= set
            };
            db.Doctor.Add(d);

            db.SaveChanges(); //1 transakcja -> 2 INS
            
            //db.Database.ExecuteSqlRaw("SELECT * FROM Emp");
        }
    }
}
