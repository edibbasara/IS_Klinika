using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class VrstaObustaveUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="Naziv je obavezno polje")]
        public string Naziv { get; set; }
        [Required(ErrorMessage="Žiro rč-broj je obavezno polje za unos")]
        [RegularExpression(@"\d{16}")]
        public string ZiroRN { get; set; }
    }
}