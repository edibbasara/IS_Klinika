using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class DijagnozaIndexVM
    {
        public class DijagnozaIndex
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Opis { get; set; }
            public int PregledId { get; set; }
        }

        public List<DijagnozaIndex> DijagnozaList { get; set; }
    }
}