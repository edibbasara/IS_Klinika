using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class VrstaObustaveIndexVM
    {
        public class VrstaObustaveInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Naziv { get; set; }
            public string ZiroRN { get; set; }
        }

        public List<VrstaObustaveIndexVM.VrstaObustaveInfo> VrsteObustaveList { get; set; }
    }
}