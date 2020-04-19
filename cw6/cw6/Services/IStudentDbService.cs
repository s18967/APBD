using cw6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Services
{
    public interface IStudentDbService
    {
        public Student GetStudent(string Index);
    }
}
