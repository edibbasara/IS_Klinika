using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class OpstinaIndexVM
    {
        public class OpstinaInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string PTT { get; set; }
            public string Naziv { get; set; }
        }

        public List<OpstinaInfo> OpstineList { get; set; }
    }
}