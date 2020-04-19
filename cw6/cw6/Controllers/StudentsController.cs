using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using cw6.Models;
using cw6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw6.Controllers
{
    [Route("API/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDbService _dbService;

        public StudentsController(IStudentDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            using (var client = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18967;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = client;
                com.CommandText = "select Student.IndexNumber, Student.FirstName, Student.LastName, BirthDate, Enrollment.Semester, Studies.Name " +
                    "from Student inner join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment " +
                    "inner join Studies on Enrollment.IdStudy = Studies.IdStudy";

                client.Open();
                var dr = com.ExecuteReader();
                String students = "";
                while (dr.Read())
                {
                    Student student = new Student();
                    student.IndexNumber = dr["IndexNumber"].ToString();
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.BirthDate = dr["BirthDate"].ToString();
                    student.Semester = dr["Semester"].ToString() + " Semestr";
                    student.Studies = dr["Name"].ToString();
                    students += student.ToString() + "\n";
                }
                return Ok(students);
            }
        }
    }
}