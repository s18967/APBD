using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;

namespace WebApplication1.Controllers
{
    [Route("api/enrollments/promotions")]
    [ApiController]
    public class EnrollmentPromoteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Promotions(EnrollPromoteRequest request)
        {
            int semestr = 0, idStudy = 0, IdEnrollment = 0;
            System.DateTime date = System.DateTime.Now;

            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18967;Integrated Security=True"))
            using (var command = new SqlCommand())
            {


                command.Connection = connection;
                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    command.CommandText = "Execute PromoteStudents @nazwa, @semestr";
                    command.Parameters.AddWithValue("nazwa", request.StudiesName);
                    command.Parameters.AddWithValue("semestr", request.Semester);

                    var dr = command.ExecuteReader();

                    if (!dr.Read())
                    {
                        transaction.Rollback();
                        return NotFound();
                    }
                    semestr = (int)dr["Semester"];
                    idStudy = (int)dr["IdStudy"];
                    IdEnrollment = (int)dr["IdEnrollment"];
                    date = (System.DateTime)dr["StartDate"];

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                }
            }
            string output = "Semestr: " + semestr + ", idStudy: " + idStudy + ", IdEnrollment: " + IdEnrollment + ", Data: " + date;
            return Ok(output);
        }
    }
}