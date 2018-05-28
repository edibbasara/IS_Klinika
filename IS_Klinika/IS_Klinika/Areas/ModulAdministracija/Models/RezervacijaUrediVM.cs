using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class RezervacijaUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime DatumPregleda { get; set; }
        public int PregledId { get; set; }
        public int PacijentId { get; set; }
        public string pacijentNaziv { get; set; }
        public int ZaposlenikId { get; set; }
        public string zaposlenikNaziv { get; set; }
        public int TerminId { get; set; }
        public bool Zavrsen { get; set; }

        //Pregled
        [Required(ErrorMessage="Opis pregleda je obavezno polje")]
        public string Opis { get; set; }
        public string HistorijaBolesti { get; set; }
        public bool Placen { get; set; }
 
        public List<SelectListItem> terminiList { get; set; }



    }
}