using System;
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
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")] 
        public IActionResult GetStudent(int id)
        {
            if ( id==1 )
            {
                return Ok("Kowalski");
            }else if ( id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
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