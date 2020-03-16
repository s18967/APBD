using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.cw3.Nowy_folder;

namespace WebApplication1.cw3
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public string GetStudent(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie = { orderBy }";
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if ( id==1)
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
    }
}