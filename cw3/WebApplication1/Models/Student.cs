using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.cw3.Nowy_folder
{
    public class Student
    {

        public string Subject { get; set; }
        public string Semester { get; set; }
        public string IdStudy { get; set; }
        public string StartDate { get; set; }
        public string IdEnrollment { get; set; }
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
    
        public string BirthDate{ get; set; } 
        public string LastName { get; set; }

        public string IndexNumber { get; set; }

        public DateTime DateOfInsert { get; set; }

        public String ToString()
        {
            return FirstName + " " + LastName + ", " + BirthDate + ". Studia: " + Subject + ", " + Semester;
        }
        public String SecondToString()
        {
            return "Id:" + IdEnrollment + ", " + Semester + ", Id kierunku: " + IdStudy + ", " + StartDate;
        }

    }
}
