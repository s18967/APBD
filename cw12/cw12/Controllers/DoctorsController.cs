using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw12.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw12.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult IdDoctor()
        {
            var db = new s18967Context();
            var doctors = db.Doctors.ToList();

            return View(doctors);
        }
        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctors doctors)
        {
            var db = new s18967Context();
            doctors.Email = "test4@wp.pl";
            db.Doctors.Add(doctors);
            db.SaveChanges();
            return RedirectToAction("IdDoctor");
        }
        public IActionResult GetDetails(int id)
        {
            var db = new s18967Context();
            var doctor = db.Doctors.FirstOrDefault(e => e.IdDoctor == id);

            return View(doctor);
        }
    }
}
