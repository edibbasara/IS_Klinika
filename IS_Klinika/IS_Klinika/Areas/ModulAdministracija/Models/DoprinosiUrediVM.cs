using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class DoprinosiUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage = "Šifra klinike je obavezna za unos")]
        public string NazivPlana { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal PIOnaPlatu { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]   
        public decimal ZdravNaPlatu { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal NezapFedNaPlatu { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal NezapKanNaPlatu { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal ZdravSolidNaPlatu { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal ZastitaOdPrirNepNaPlatu { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal PIOizPlate { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal ZdravIzPlate { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal NezapFedIzPlate { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal NezapKanIzPlate { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal ZdravSolidIzPlate { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal PorezNaPlatuOsnov { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public decimal PoreznaPlatu { get; set; }

    }
}