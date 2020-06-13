using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw12.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            InverseDoctorIdDoctorNavigation = new HashSet<Doctors>();
        }
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? DoctorIdDoctor { get; set; }

        public virtual Doctors DoctorIdDoctorNavigation { get; set; }
        public virtual ICollection<Doctors> InverseDoctorIdDoctorNavigation { get; set; }
    }
}
