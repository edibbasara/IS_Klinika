using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class ProizvodIndexVM
    {
        public class ProizvodInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Naziv { get; set; }
            public decimal Cijena { get; set; }
            public decimal Popust { get; set; }
        }

        public List<ProizvodInfo> ProizvodiList { get; set; }
    }
}