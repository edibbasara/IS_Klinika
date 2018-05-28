using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class RacunStavkeIndexVM
    {
        public class RacunStavkeInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public int Kolicina { get; set; }
            public int RacunId { get; set; }
            public int ProizvodId { get; set; }
            public string ProizvodNaziv { get; set; }
            public decimal ProizodCijena { get; set; }
            public int PDVStopeId { get; set; }
            public string PDVStopeNaziv { get; set; }
            public decimal PDV { get; set; }
            public decimal IznosPDV { get; set; }
            public decimal IznosBezPDV { get; set; }
            public decimal IznosSaPDV { get; set; }
            public decimal Popust { get; set; }
            public decimal PopustIznos { get; set; }
        }

        public List<RacunStavkeIndexVM.RacunStavkeInfo> RacunStavkeList { get; set; }

    }
}