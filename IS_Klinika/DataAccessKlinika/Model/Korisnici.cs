using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Korisnici:IEntity
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
        public DateTime? DatumRodjenja { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}
