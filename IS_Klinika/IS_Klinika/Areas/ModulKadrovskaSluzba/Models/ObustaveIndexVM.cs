using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class ObustaveIndexVM
    {
        public class ObustaveInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public decimal Iznos { get; set; }
            public decimal RataIznos { get; set; }
            public int BrojRata { get; set; }
            public DateTime? DatumIzdavanja { get; set; }
            public DateTime? DatumPrestanka { get; set; }
            public bool Aktivan { get; set; }
            public int ZaposlenikId { get; set; }
            public string ZaposlenikNaziv { get; set; }
            public int VrstaObustaveId { get; set; }
            public string VrsteObustavaNaziv { get; set; }
        }

        public List<ObustaveInfo> ObustaveList { get; set; }
        public int zapID { get; set; }
    }
}