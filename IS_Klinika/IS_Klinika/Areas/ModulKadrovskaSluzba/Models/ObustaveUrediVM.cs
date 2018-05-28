using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class ObustaveUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage = "Iznos je obavezno polje")]
        [RegularExpression(@"([0-9,]){1,6}",ErrorMessage="Dozvoljen unos samo brojčanih vrjednosti")]
        public decimal Iznos { get; set; }
        [Required(ErrorMessage="Iznos rate je obavezno polje za unos")]
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljen unos samo brojčanih vrjednosti")]
        public decimal RataIznos { get; set; }
        [Required(ErrorMessage="Broj rata je obavezno polje za unos")]
        [RegularExpression(@"\d{1,4}", ErrorMessage = "Dozvoljen unos samo brojčanih vrjednosti")]
        public int BrojRata { get; set; }
        [Required(ErrorMessage="Datum izdavanja je obavezno polje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumIzdavanja { get; set; }
        [Required(ErrorMessage = "Datum prestanka je obavezno polje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{00:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumPrestanka { get; set; }
        public bool Aktivan { get; set; }
        public int ZaposlenikId { get; set; }
        [Required(ErrorMessage="Vrsta obustave je obavezno za izbor")]
        public int VrstaObustaveId { get; set; }

        public List<SelectListItem> ZaposleniciList { get; set; }
        public List<SelectListItem> VrsteObustavaList { get; set; }
    }
}