using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace probny_kolos_2.Models
{
    public class Klient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public ICollection<Klient> Klients { get; set; }
    }
}
