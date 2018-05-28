using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class DijagnozaUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="Dijagnoza pregleda je obavezna za unos")]
        public string Opis { get; set; }
        public int PregledId { get; set; }

        //Pregled 
        [Required(ErrorMessage="Opis potrebnog pregleda je obavezan unos")]
        public string OpisPregled { get; set; }
        public string HistorijBolesti { get; set; }

        //Pacijent
        public int pacId { get; set; }
    }
}