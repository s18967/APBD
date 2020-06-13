using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace probny_kolos_2.Models
{
    public class Zamow_wyrob
    {
        [ForeignKey("WyrobCukierniczy")]
        public int IdWyrobuCukierniczego { get; set; }
        [ForeignKey("Zamowienie")]
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }
        [MaxLength(300)]
        public string Uwagi { get; set; }
        public ICollection<Zamow_wyrob> Zamow_wyroby { get; set; }
    }
}
