using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace probny_kolos_2.Models
{
    public class Pracownik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPracownik { get; set; }
        [MaxLength(50)]
        public string Imie { get; set; }
        [MaxLength(60)]
        public string Nazwisko { get; set; }
        public ICollection<Pracownik> Pracownicy { get; set; }
    }
}
