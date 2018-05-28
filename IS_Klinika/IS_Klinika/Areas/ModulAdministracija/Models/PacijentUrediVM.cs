using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class PacijentUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumRegistracije { get; set; }
        public string AktivacijskiHash { get; set; }
        public bool IsPotvrdjen { get; set; }
        [Required(ErrorMessage="Opština prebivališta je obavezno polje")]
        public int? OpstinaPrebivalistaId { get; set; }
        [Required(ErrorMessage = "Opština prebivališta je obavezno polje")]
        public int? OpstinaRodzenjaId { get; set; }
        public int? KrvnaGrupaId { get; set; }
        [Required(ErrorMessage="Izbor klinike je obavezan za unos")]
        public int KlinikaId { get; set; }
        //Korisnik

        [Required(ErrorMessage="Ime pacijenta je obavezno za unos")]
        public string Ime { get; set; }
        [Required(ErrorMessage="Prezime pacijenta je obavezno za unos")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Korisničko ime pacijenta je obavezno za unos")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage="Lozinka je obavezna za unos")][StringLength(20,ErrorMessage="Lozinka treba sadržavati minimalno 7 karaktera a max. 20 karaktera",MinimumLength=5)]
        public string Lozinka { get; set; }
        [Required(ErrorMessage="Adresa je obavezno polje za unos")]
        public string Adresa { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-./ ]?([0-9]{3})[-./ ]?([0-9]{3,4})$", ErrorMessage = "Unesite isparavno br tel.(0-10 br. znakovi ()/-. ")]
        public string Tel { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-./ ]?([0-9]{3})[-./ ]?([0-9]{3,4})$", ErrorMessage = "Unesite isparavno br tel.(0-10 br. znakovi ()/-. ")]
        public string Mob { get; set; }
        [Required(ErrorMessage="Datum rodženja je obavezan za unos")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumRodjenja { get; set; }


        public List<SelectListItem> KrvnaGrupaLista { get; set; }
        public List<SelectListItem> OpstineList { get; set; }
        public List<SelectListItem> KlinikeList { get; set; }
        public List<SelectListItem> ZaposleniciList { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumPregleda { get; set; }
        [Required]
        public int zaposlenikId { get; set; }
    }
}