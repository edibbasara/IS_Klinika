using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class ProizvodUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="Naziv proizvoda je obavezno polje za unos")]
        public string Naziv { get; set; }
        [Required(ErrorMessage="Cijena proizvoda je obavezna za unos")]
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal Cijena { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal Popust { get; set; }
    }
}