using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace probny_kolos_2.Models
{
    public class Zamowienie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        [MaxLength(300)]
        public string Uwagi { get; set; }
        [ForeignKey("Klient")]
        public int IdKlient { get; set; }
        [ForeignKey("Pracownik")]
        public int IdPracownik { get; set; }
    }
}
