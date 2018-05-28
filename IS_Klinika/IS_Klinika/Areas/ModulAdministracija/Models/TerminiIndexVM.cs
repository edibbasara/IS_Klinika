using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class TerminiIndexVM
    {
        public class TerminiInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Sati { get; set; }
            public string Minuti { get; set; }
            public int SmjenaId { get; set; }
            public string SmjenaNaziv { get; set; }
        }

        public List<TerminiInfo> TerminiList { get; set; }
        public int SmjID { get; set; }
    }
}