using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class RadnoMjesto:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Koefcijent { get; set; }
        public decimal Osnovica { get; set; }
    }
}
