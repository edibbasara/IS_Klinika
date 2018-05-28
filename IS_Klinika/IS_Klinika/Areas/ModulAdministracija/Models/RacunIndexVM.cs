using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class RacunIndexVM
    {
        public class RacunInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public decimal PDVIznosUkupno { get; set; }
            public decimal IznosUkupno { get; set; }
            public decimal IznosBezPDVUkupno { get; set; }
            public DateTime Datum { get; set; }
            public int PregledId { get; set; }
        }

        public List<RacunInfo> RacuniLista { get; set; }
    }
}