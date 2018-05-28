using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class RacunUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public decimal PDVIznosUkupno { get; set; }
        public decimal IznosUkupno { get; set; }
        public decimal IznosBezPDVUkupno { get; set; }
        public decimal Popust { get; set; }
        public DateTime Datum { get; set; }
        public int PregledId { get; set; }

        //Racun stavke podaci

        public List<RacunStavkeIndexVM.RacunStavkeInfo> StavkeList { get; set; }
        public List<SelectListItem> ProizvodiList { get; set; }
        public List<SelectListItem> StopePDVList { get; set; }
        public int StopePDVId { get; set; }
        public int ProizvodId { get; set; }
        public int Kolicina { get; set; }
    }
}