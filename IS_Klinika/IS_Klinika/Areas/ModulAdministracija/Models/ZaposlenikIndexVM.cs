using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class ZaposlenikIndexVM 
    {
        public class ZaposlenikInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public bool IsAdministrator { get; set; }
            public bool IsKadrovskoOsoblje { get; set; }
            public bool IsMedicinskoOsoblje { get; set; }
            public bool IsDoktor { get; set; }
            public DateTime PocetakRada { get; set; }
            public DateTime? KrajRada { get; set; }
            public int KlinikaId { get; set; }
            public string KlinikaNaziv { get; set; }
            public int SmjenaId { get; set; }
            public string SmjenaNaziv { get;set;}
            public int RadnoMjestoId { get; set; }
            public string RadnoMjestoNaziv { get;set; }
            public int? OpstinaPrebivalistaID { get; set; }
            public string OpstinaPrebivalistaNaziv { get;set; }
   

            //Korisnik
            public string ImePrezime { get; set; }
            public string Adresa { get; set; }
            public string Email { get; set; }
            public string Tel { get; set; }
            public string Mob { get; set; }
        }

        public List<ZaposlenikInfo> ZaposleniciLista { get; set; }

        public List<SelectListItem> KlinikaList { get; set; }
    }
}
