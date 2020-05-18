using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using cw10.Models;
using cw10.Requests;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly s18967Context db;

        public EnrollmentsController(s18967Context _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            if (!(db.Student.Where(s => s.IndexNumber == request.IndexNumber).Any()))
            {
                if (db.Studies.Where(s => s.Name == request.Studies).Any())
                {
                    var studies = db.Studies.SingleOrDefault(s => s.Name == request.Studies);
                    var date = db.Enrollment.Max(d => d.StartDate);

                    if (!(db.Enrollment.Where(e => (e.Semester == 1) && (e.IdStudy == studies.IdStudy) && (e.StartDate == date)).Any()))
                    {
                        int id = db.Enrollment.Max(i => i.IdEnrollment);
                        Enrollment enrollment = new Enrollment
                        {
                            IdEnrollment = id,
                            Semester = 1,
                            IdStudy = studies.IdStudy,
                            StartDate = Convert.ToDateTime(DateTime.Now)
                        };
                        db.Enrollment.Add(enrollment);
                        db.SaveChanges();
                    }

                    var enroll = db.Enrollment.SingleOrDefault(e => (e.Semester == 1) && (e.IdStudy == studies.IdStudy) && (e.StartDate == date));
                    Student student = new Student
                    {
                        IndexNumber = request.IndexNumber,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        BirthDate = Convert.ToDateTime(request.Birthdate),
                        IdEnrollment = enroll.IdEnrollment
                    };
                    db.Student.Add(student);
                    db.SaveChanges();
                    return Ok("Dodano nowego studenta");
                }
            }
            return NotFound("Podano błędnie, któryś z argumentów wew. requesta");
        }
    }
}