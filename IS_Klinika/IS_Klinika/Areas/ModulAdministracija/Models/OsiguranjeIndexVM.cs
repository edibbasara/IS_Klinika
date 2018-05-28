using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class OsiguranjeIndexVM
    {
        public class osiguranjeInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string NazivPoslodavca { get; set; }
            public string Adresa { get; set; }
            public int OpstinaId { get; set; }
            public string OpstinaNaziv { get; set; }
            public string RadnoMjesto { get; set; }
            public DateTime? OsiguranOd { get; set; }
            public DateTime? OsiguranDo { get; set; }
            public int PacijentId { get; set; }
        }

        public List<osiguranjeInfo> OsiguranjeLista { get; set; }
        public int pacId { get; set; }
    }
}