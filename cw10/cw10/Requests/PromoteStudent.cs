using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw10.Requests
{
    public class PromoteStudent
    {
        [Required]
        public int Semester { get; set; }
        [Required]
        public string Studies { get; set; }

    }
}
