using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using probny_kolos_2.Models;

namespace probny_kolos_2.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class KlientController : ControllerBase
    {
        private readonly PeopleDbContext db;

        public KlientController(PeopleDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetKlients()
        {
            string result = "";

            foreach (var d in db.Klients)
            {
                result = "";
            }

            return Ok(result);
        }
        [HttpGet("{nazwisko}")]
        public IActionResult GetKlient(string nazwisko)
        {
            string result = "";
            List<int> idZamowien = new List<int>();
            List<int> idZamowWyrob = new List<int>();
            Dictionary<int, int> iloscZamowionychRzeczy = new Dictionary<int, int>();


            if (db.Klients.Where(e => e.Nazwisko == nazwisko).Any())
            {
                //nie uwzględniam brania wszystkich osób o danym nazwisku
                var res = db.Klients.SingleOrDefault(e => e.Nazwisko == nazwisko);

                foreach (var d in db.Zamowienia)
                {
                    if(d.IdKlient == res.IdKlient)
                    {
                        idZamowien.Add(d.IdZamowienia);
                    }
                    else
                    {
                        return NotFound("Klient " + nazwisko + " nie posiada żadnego zakupu");
                    }
                    
                    foreach (var z in db.Zamow_wyroby)
                    {
                        if (idZamowien.Contains(z.IdZamowienia))
                        {
                            if(!iloscZamowionychRzeczy.ContainsKey(z.IdWyrobuCukierniczego))
                                iloscZamowionychRzeczy.Add(z.IdWyrobuCukierniczego, z.Ilosc);
                            else
                            {
                                int ilosc = iloscZamowionychRzeczy.GetValueOrDefault(z.IdWyrobuCukierniczego);
                                iloscZamowionychRzeczy.Remove(z.IdWyrobuCukierniczego);
                                iloscZamowionychRzeczy.Add(z.IdWyrobuCukierniczego, ilosc + z.Ilosc);
                            }
                        }
                        else
                        {
                            return NotFound("Błąd w systemie, Zamowienie nie zawiera żadnego wyrobu");
                        }
                    }
                }
                foreach(var row in iloscZamowionychRzeczy)
                {
                    var wyrob = db.WyrobyCukiernicze.Where(w => w.IdWyrobuCukierniczego == row.Key).FirstOrDefault();
                    string nazwa = wyrob.Nazwa;

                    result += nazwa + " " + row.Value+"\n";
                }
                return Ok(result);
            }
            return NotFound("Nie istnieje klient o takim nazwisku.");
        }
    }
}

