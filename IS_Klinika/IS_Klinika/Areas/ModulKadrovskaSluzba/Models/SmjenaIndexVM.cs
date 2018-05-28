using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class SmjenaIndexVM
    {
        public class SmjenaInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Naziv { get; set; } 
        }
        public List<SmjenaInfo> SmjenaList { get; set; }
    }
}