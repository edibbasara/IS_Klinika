using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class ObracunUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="Izbor mjeseca obračuna je obavezan")]
        public string Mjesec { get; set; }
        [Required(ErrorMessage="Izbor godine je obavezan")]
        public string Godina { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int RPV { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int PR { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int GO { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int BD42D { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int BP42D { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int DP { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int RN { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int NS { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int NR { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public int RDP { get; set; }
        public int ZaposlenikId { get; set; }
        public string ZaposlenikImePrezime { get; set; }
        [Required(ErrorMessage="Izbor plana obračuna doprinosa je obavezan")]
        public int DoprinosiId { get; set; }
        [Required(ErrorMessage="Obavezan unos datuma")][DataType(DataType.Date)]
        public DateTime? PeriodOD { get; set; }
        [Required(ErrorMessage = "Obavezan unos datuma")]
        [DataType(DataType.Date)]
        public DateTime? PeriodDO { get; set; }
        public DateTime DatumObracuna { get; set; }

        //Obracun doprinosi

        public decimal PIOnaPlatu { get; set; }
        public decimal ZdravNaPlatu { get; set; }
        public decimal NezapFedNaPlatu { get; set; }
        public decimal NezapKanNaPlatu { get; set; }
        public decimal ZdravSolidNaPlatu { get; set; }
        public decimal ZastitaOdPrirNepNaPlatu { get; set; }
        public decimal PIOizPlate { get; set; }
        public decimal ZdravIzPlate { get; set; }
        public decimal NezapFedIzPlate { get; set; }
        public decimal NezapKanIzPlate { get; set; }
        public decimal ZdravSolidIzPlate { get; set; }
        public decimal PorezNaPlatuOsnov { get; set; }
        public decimal PoreznaPlatu { get; set; }

        public List<SelectListItem> DoprinosiList { get; set; }
        public List<SelectListItem> MjeseciList { get; set; }
        public List<SelectListItem> GodineList { get; set; }
    }
}