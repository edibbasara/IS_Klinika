using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Api.Models
{
    public class AutentifikacijaVM
    {
        //Korisnici
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string ImePrezime{ get; set; }
        public string KorisnickoIme { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        

        //Pacijent
        public string AktivacijskiHash { get; set; }
        public bool IsPotvrdjen { get; set; }
        public string PacOpstinaPrebivalistaNaziv { get; set; }
        public string KlinikaPac { get; set; }

        //Rezervacije
        public class RezervacijeInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public DateTime DatumRezervacije { get; set; }
            public DateTime DatumPregleda { get; set; }
            public int PregledId { get; set; }
            public int PacijentId { get; set; }
            public string PacijentNaziv { get; set; }
            public int ZaposlenikId { get; set; }
            public string ZaposlenikNaziv { get; set; }
            public int TerminId { get; set; }
            public string Termin { get; set; }
            public bool Zavrsen { get; set; }
        }

        public List<RezervacijeInfo> RezervacijaList { get; set; }
    }
}