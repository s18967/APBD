using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Responses
{
    public class EnrollStudentResponse
    {
        public string LastName { get; set; }
        public string StudiesName { get; set; }
        public int Semester { get; set; }
        public DateTime StartDate { get; set; }
    }
}
