using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Requests
{
    public class EnrollPromoteRequest
    {
        [Required]
        public string StudiesName{ get; set; }
        [Required]
        [Range(1,9)]
        public int Semester { get; set; }
    }
}
