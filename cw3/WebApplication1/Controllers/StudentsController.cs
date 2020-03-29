using System;
using System.Data.SqlClient;
using cw3.DAL;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.cw3.Nowy_folder;

namespace WebApplication1.cw3
{
    [Route("API/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
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
                com.CommandText = "select Student.FirstName, Student.LastName, Student.BirthDate, Studies.Name, Enrollment.Semester " +
                    "from Student inner join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment " +
                    "inner join Studies on Enrollment.IdStudy = Studies.IdStudy";

                client.Open();
                var dr = com.ExecuteReader();
                String students = "";
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.Subject = dr["Name"].ToString();
                    st.Semester = dr["Semester"].ToString() + " semestr";
                    students += st.ToString() + "\n";
                }
            return Ok(students);
            }
        }

        [HttpGet("{id}")] 
        public IActionResult GetStudent(String id)
        {
            string myId = "s1234";
            string SqlID = "'" + id + "'";
            using (var client = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18967;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = client;
                com.CommandText = "select enrollment.IdEnrollment, semester, Enrollment.IdStudy, StartDate" +
                    " from studies inner join enrollment on studies.IdStudy=enrollment.IdStudy "
                    +"inner join Student on Enrollment.IdEnrollment=Student.IdEnrollment where IndexNumber = "+ SqlID;
                com.Parameters.AddWithValue("id", myId);

                client.Open();
                var dr = com.ExecuteReader();
                String student = "";
                while (dr.Read())
                {
                    var st = new Student();
                    st.IdEnrollment = dr["IdEnrollment"].ToString();
                    st.Semester = dr["Semester"].ToString() + " semestr";
                    st.IdStudy = dr["IdStudy"].ToString();
                    st.StartDate = dr["StartDate"].ToString();
                    student += st.SecondToString();
                }
                return Ok(student);
            }
        }
        
        [HttpPost]
        public IActionResult CreateStudent (Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent (int id, Student student)
        {
            if (id == student.IdStudent)
            {
                student.DateOfInsert = DateTime.Now;
                student.IndexNumber = student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            }

            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent (int id, Student student)
        {
            if (student.IdStudent == id)
            {
                student = null;
            }
            return Ok("Usuwanie ukończone");
        }
    }
}