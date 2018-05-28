using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class OsiguranjeUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage="Naziv poslodavca je obavezno polje za unos")]
        public string NazivPoslodavca { get; set; }
        [Required(ErrorMessage="Adresa je obavezno polje za unos")]
        public string Adresa { get; set; }
        [Required(ErrorMessage="Izbor općine je obavezno polje za unos")]
        public int OpstinaId { get; set; }
        public string OpstinaNaziv { get; set; }
        public string LicniBrOsig { get; set; }
        [RegularExpression(@"\d{10}")]
        public string RegBr { get; set; }
        public string Zajednica { get; set; }
        [Required(ErrorMessage="Radno mjesto je obavezno polje za unos")]
        public string RadnoMjesto { get; set; }
        [Required(ErrorMessage="Osiguran od datuma je obavezno polje za unos")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OsiguranOd { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OsiguranDo { get; set; }
        public int PacijentId { get; set; }
        public string PacijentImePrezime { get; set; }

        public List<SelectListItem> OpstineList { get; set; }

    }
}