using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class KlinikaUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="Šifra klinike je obavezna za unos")]
        public string Sifra { get; set; }
        [Required(ErrorMessage="Naziv klinike je obavezan za unos")]
        public string Naziv { get; set; }
        [Required(ErrorMessage="Vrsta klinike je obavezna za unos")]
        public string Vrsta { get; set; }
        [Required(ErrorMessage="Adresa klinike je obavezna za unos")]
        public string Adresa { get; set; }
        [Required(ErrorMessage="ID broj je obavezan za unos")]
        public string IdBroj { get; set; }
        [Required(ErrorMessage = "PDV broj je obavezan za unos")]
        public string PDVbroj { get; set; }
        [Required(ErrorMessage = "Broj zdravstvene institucije je obavezan za unos")]
        public string ZdravInstitBr { get; set; }
        [Required(ErrorMessage = "Koefcijent obracuna redovnog rada je obavezan za unos")]
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public double KoefRPV { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public double KoefPR { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public double KoefGO { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public double KoefBD42D { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public double KoefBP42D { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public double KoefRN { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public double KoefNS { get; set; }
        [RegularExpression(@"([0-9,]){1,6}", ErrorMessage = "Dozvoljena samo brojčana vrijednost 1 - 1,11111")]
        public double KoefNR { get; set; }
        public double KoefRDP { get; set; }
        [Required(ErrorMessage = "ID broj je obavezan za unos")]
        public int OpstinaId { get; set; }
        

        public List<SelectListItem> OpstineList { get; set; }
        
    }
}