using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class PacijentIndexVM
    {
        public class PacijentInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Adresa { get; set; }
            public DateTime? DatumRegistracije { get; set; }
            public string AktivacijskiHash { get; set; }
            public bool IsPotvrdjen { get; set; }
            public int? OpstinaPrebivalistaId { get; set; }
            public string OpstinaPrebivalistaNaziv { get; set; }
            public string KlinikaNaziv { get; set; }
            public int KlinikaId { get; set; }
        }

        public List<PacijentIndexVM.PacijentInfo> ListaPacijenata { get; set; }

        public List<SelectListItem> KlinikaList { get; set; }
        
        public List<SelectListItem> OpstinaList { get; set; }
    }
}