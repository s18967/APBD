using System.Collections.Generic;
using WebApplication1.cw3.Nowy_folder;

namespace cw3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();

    }
}
