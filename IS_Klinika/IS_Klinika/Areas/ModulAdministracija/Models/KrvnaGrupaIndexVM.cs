using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class KrvnaGrupaIndexVM
    {
        public class KrvnaGrupaInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Naziv { get; set; }
            public string RHFaktor { get; set; }
        }

        public List<KrvnaGrupaIndexVM.KrvnaGrupaInfo> KrvnaLista { get; set; }
    }
}