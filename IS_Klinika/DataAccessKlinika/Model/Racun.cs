using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Racun:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public decimal PDVIznosUkupno { get; set; }
        public decimal IznosUkupno { get; set; }
        public decimal IznosBezPDVUkupno { get; set; }
        public decimal Popust { get; set; }
        public DateTime Datum { get; set; }
        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }
    }
}
