using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDbContext _context;

        public PeopleController(PeopleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors.ToList());
        }

        public IActionResult AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            return Ok(_context.Doctors.Find(doctor));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id)
        {
            if (_context.Doctors.Where(d => d.IdDoctor == id).Any())
            {
                var res = _context.Doctors.SingleOrDefault(s => s.IdDoctor == id);
                res.Email = "ModifiedEmail@wp.pl";
                _context.SaveChanges();
                return Ok("Zmodyfikowano " + DateTime.Now);
            }
            return NotFound("Złe id lekarza");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            if (_context.Doctors.Where(s => s.IdDoctor == id).Any())
            {
                var res = _context.Doctors.SingleOrDefault(s => s.IdDoctor == id);
                _context.Doctors.Remove(res);
                String result = res.ToString();
                _context.SaveChanges();
                return Ok("Usunieto " + result);
            }
            return NotFound("Nie ma doktora o takim id");
        }

    }
}
