using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class KrvnaGrupaUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="Naziv je obavezno polje za unos")]
        public string Naziv { get; set; }
        [Required(ErrorMessage="Polje obavezno za unos")]
        public string RHFaktor { get; set; }
    }
}