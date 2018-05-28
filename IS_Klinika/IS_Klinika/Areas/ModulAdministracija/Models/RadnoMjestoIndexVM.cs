using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class RadnoMjestoIndexVM
    {
        public class RadnoMjestoInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            [Required(ErrorMessage="Šifra radnog mjesta je obavezna za unos")] 
            public string Sifra { get; set; }
            [Required(ErrorMessage="Naziv je obavezno polje za unos")]
            public string Naziv { get; set; }
            public string Opis { get; set; }
            [Required(ErrorMessage="Koefcijent je obavezan za unos")]
            [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
            public decimal Koefcijent { get; set; }
            [Required(ErrorMessage = "Koefcijent je obavezan za unos")]
            [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
            public decimal Osnovica { get; set; }
        }
        public List<RadnoMjestoInfo> RadnaMjestaList { get; set; }
    }
}