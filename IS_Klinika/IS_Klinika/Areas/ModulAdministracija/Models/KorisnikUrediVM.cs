using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class KorisnikUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Mob { get; set; }
        public string JMBG { get; set; }
        public string LKbr { get; set; }
        public DateTime? DatumRodjenja { get; set; }

    }
}