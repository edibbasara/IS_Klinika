using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class OpstinaUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="PTT broj opštine je obavezan za unos")]
        public string PTT { get; set; }
        [Required(ErrorMessage="Naziv opštine je obavezan za unos")]
        public string Naziv { get; set; }
    }
}