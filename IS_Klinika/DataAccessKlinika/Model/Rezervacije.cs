using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Rezervacije:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime DatumPregleda { get; set; }
        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
        public int ZaposlenikId { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
        public int TerminId { get; set; }
        public Termin Termin { get; set; }
        public bool Zavrsen { get; set; }

    }
}
