using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class TerminiUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage = "Sat termina je obavezan unos")]
        [RegularExpression(@"\d{2}", ErrorMessage = "Format unosa sata je '00'")]
        public string Sati { get; set; }
        [Required(ErrorMessage="Minuta termina je obavezan unos")]
        [RegularExpression(@"\d{2}",ErrorMessage="Format unosa minuta je '00'")]
        public string Minuti { get; set; }
        public int SmjenaId { get; set; }

        public string SmjenaNaziv { get; set; }
  
    }
}