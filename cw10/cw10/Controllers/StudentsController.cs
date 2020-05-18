using System;
using System.Data.SqlClient;
using System.Linq;
using cw10.Models;
using Microsoft.AspNetCore.Mvc;

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

            var res = db.Student.ToList();

            if (res.Count > 1)
            {
                return Ok(res);
            }

            return NotFound("Nie znaleziono studentow");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(String id)
        {
            var res = db.Student;

            if (res.Find().IndexNumber.Equals(id)) {
                //res.Update();
                return Ok("Zmodyfikowany");
            }
            return NotFound("Podano zly index");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(String id)
        {
            var res = db.Student;

            foreach(var d in res)
            {
                if (d.IndexNumber.Equals(id))
                {
                    res.Remove(d);
                    return Ok("Usuwanie zakonczone");
                }
            }
            return Ok("Nie znaleziono osoby o takim indexie");
        }
    }
}