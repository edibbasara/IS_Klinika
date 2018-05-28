using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class RadniRasporedIndexVM
    {
        public class RadniRasporedInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public DateTime? DatumOD { get; set; }
            public DateTime? DatumDO { get; set; }
            public int ZaposlenikID { get; set; }
            public string ImePrezime { get; set; }
            public int SmjenaId { get; set; }
            public string SmjenaNaziv { get; set; }
        }
        public List<RadniRasporedInfo> RadniRasporedLista { get; set; }
        

    }
}