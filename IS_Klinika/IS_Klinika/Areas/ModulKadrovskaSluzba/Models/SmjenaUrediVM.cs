using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class SmjenaUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="Naziv je obavezno polje")]
        public string Naziv { get; set; } 
    }
}