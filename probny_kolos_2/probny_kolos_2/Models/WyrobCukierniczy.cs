using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace probny_kolos_2.Models
{
    public class WyrobCukierniczy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWyrobuCukierniczego { get; set; }
        [MaxLength(200)]
        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        [MaxLength(40)]
        public string Typ { get; set; }
        public ICollection<WyrobCukierniczy> WyrobyCukiernicze { get; set; }

    }
}
