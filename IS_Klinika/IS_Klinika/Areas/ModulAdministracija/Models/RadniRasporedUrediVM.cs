using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class RadniRasporedUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage = "Datum početka je obavezno polje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumOD { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumDO { get; set; }
        [Required(ErrorMessage = "Izbor zaposlenimka je obavezan")]
        public int ZaposlenikID { get; set; }
        [Required(ErrorMessage = "Izbor smjene je obavezan")]
        public int SmjenaId { get; set; }

        public List<SelectListItem> ZaposleniciLista { get; set; }
        public List<SelectListItem> SmjenaLista { get; set; }
    }
}