using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class ObracunIndexVM
    {
        public class ObracunInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Mjesec { get; set; }
            public string Godina { get; set; }
            public int ZaposlenikId { get; set; }
            public string ZaposlenikIme { get; set; }
            public int DoprinosiId { get; set; }
            public string DoprinosiNaziv { get; set; }
            public DateTime? PeriodOD { get; set; }
            public DateTime? PeriodDO { get; set; }
            public DateTime DatumObracuna { get; set; }
        }

        public List<ObracunIndexVM.ObracunInfo> ObracunList { get; set; }
        public int ZapId { get; set; }
    }
}