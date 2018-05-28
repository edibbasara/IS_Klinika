using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class ZaposlenikUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsKadrovskoOsoblje { get; set; }
        public bool IsMedicinskoOsoblje { get; set; }
        public bool IsDoktor { get; set; }
        public string Banka { get; set; }
        public string Konto { get; set; }
        public double KoefLO { get; set; }
        public string PIOregBr { get; set; }
        public string PIOdjelBr { get; set; }
        public string MinuliRad { get; set; }
        public DateTime PocetakRada { get; set; }
        public DateTime? KrajRada { get; set; }
        public int KlinikaId { get; set; }
        public int SmjenaId { get; set; }
        public int RadnoMjestoId { get; set; }
        public string JMBG { get; set; }
        public string LKbr { get; set; }
        public int? OpstinaRodzenjaId { get; set; }
        public int? OpstinaPrebivalistaId { get; set; }
        
        //Korisnik
        public bool KorisnikValid { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Mob { get; set; }
        public DateTime? DatumRodjenja { get; set; }

        public List<SelectListItem> OpstinaList { get; set; }

        public List<SelectListItem> RadnoMjestoList { get; set; }
 
        public List<SelectListItem> SmjenaList { get; set; }

        public List<SelectListItem> KlinikaList { get; set; }
    }
}