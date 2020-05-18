using System;
using System.Data.SqlClient;
using System.Linq;
using cw10.Models;
using cw10.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cw10
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly s18967Context db;
        public StudentsController()
        {
            db = new s18967Context();
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(db.Student.ToList());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(String id)
        {
            if (db.Student.Where(s => s.IndexNumber == id).Any())
            {
                var res = db.Student.SingleOrDefault(s => s.IndexNumber == id);
                res.Modified = DateTime.Now;
                db.SaveChanges();
                return Ok("Zmodyfikowano "+DateTime.Now);
            }
            return NotFound("Podano zly index");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(String id)
        {
            if(db.Student.Where(s => s.IndexNumber == id).Any())
            {
                var res = db.Student.SingleOrDefault(s => s.IndexNumber == id);
                db.Student.Remove(res);
                String result = res.ToString();
                db.SaveChanges();
                return Ok("Usunieto " + result);
            }
            return NotFound("Nie ma ucznia o takim id");
        }

        [Route("/api/students/promotions")]
        [HttpPost]
        public IActionResult PromoteStudents(PromoteStudent promotions)
        {
            var res = from enroll in db.Enrollment
                      join studies in db.Studies on enroll.IdStudy equals studies.IdStudy
                      where enroll.Semester == promotions.Semester && studies.Name == promotions.Studies
                      select enroll;

            if (res!=null)
            {
                var data = new object[2] { promotions.Studies, promotions.Semester };
                db.Database.ExecuteSqlRaw("EXEC PromoteStudents @StudiesName,@Semester", data);
                db.SaveChanges();
                return Ok("Student awansowal na kolejny semestr");
            }

            return NotFound();
        }
    }
}