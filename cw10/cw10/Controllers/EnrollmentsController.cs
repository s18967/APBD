using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
/*
namespace cw10.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult EnrollStudent(EnrollPromoteStudent request)
        {
            var st = new Student();
            st.Subject = request.Studies;
            st.Semester = "1";
            st.LastName = request.LastName;

            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18967;Integrated Security=True"))
            using (var command = new SqlCommand())
            {

                command.Connection = connection;
                connection.Open();
                var transaction = connection.BeginTransaction();


                //1. Czy studia istnieja?
                try
                {
                    command.CommandText = "select IdStudies from Studies where name=@name";
                    command.Parameters.AddWithValue("name", request.Studies);

                    var dr = command.ExecuteReader();

                    if (!dr.Read())
                    {
                        transaction.Rollback();
                        return BadRequest("Studia nie istnieja.");
                    }
                    int idStudies = (int)dr["IdStudies"];
                    //Następnie odnajdujemy najnowszy wpis w tabeli Enrollments
                    //zgodny ze studiami studenta i wartością Semester = 1(student zapisuje się na pierwszy
                    //semestr).

                    command.CommandText = "select * from Enrollment " +
                        "where StartDate = (select MAX(StartDate) from Enrollment where idStudy=" + idStudies + ") " +
                        "AND Semester=1";

                    var execread = command.ExecuteReader();

                    //Jeśli tak wpis nie istnieje to dodajemy go do bazy danych (StartDate ustawiamy na aktualną datę).
                    //Na końcu dodajemy wpis w tabeli Students.
                    if (!execread.Read())
                    {
                        command.CommandText = "Insert into Enrollment values (" +
                            "(SELECT MAX(idEnrollment)+1 from Enrollment),1," + idStudies + ",GetDate()";
                    }
                    //Pamiętamy o tym, aby sprawdzić czy indeks podany przez studenta jest unikalny. W przeciwnym
                    //wypadku zgłaszamy błąd.
                    command.CommandText = "Select * from Student WHERE IndexNumber=@indexNumber";
                    command.Parameters.AddWithValue("indexNumber", request.IndexNumber);

                    var studentread = command.ExecuteReader();

                    if (!studentread.Read())
                    {
                        transaction.Rollback();
                        return BadRequest("Index jest nieunikalny.");
                    }
                    command.CommandText = "Insert into Student values(" +
                                                                       request.IndexNumber + "," +
                                                                       request.FirstName + "," +
                                                                       request.LastName + "," +
                                                                       request.BirthDate + "," +
                                                                       idStudies +
                                                                     ")";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                }

            }

            response.StudiesName = st.Subject;
            response.Semester = int.Parse(st.Semester);
            response.LastName = st.LastName;
            return Ok(response + ". Nie wiem jak zwrocic Created");
        }
    }
}*/