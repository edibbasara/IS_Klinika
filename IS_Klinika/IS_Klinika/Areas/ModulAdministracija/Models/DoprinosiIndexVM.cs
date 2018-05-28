using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class DoprinosiIndexVM
    {
        public class DoprinosiInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string NazivPlana { get; set; }
            public decimal PIOnaPlatu { get; set; }
            public decimal ZdravNaPlatu { get; set; }
            public decimal NezapFedNaPlatu { get; set; }
            public decimal NezapKanNaPlatu { get; set; }
            public decimal ZdravSolidNaPlatu { get; set; }
            public decimal ZastitaOdPrirNepNaPlatu { get; set; }
            public decimal PIOizPlate { get; set; }
            public decimal ZdravIzPlate { get; set; }
            public decimal NezapFedIzPlate { get; set; }
            public decimal NezapKanIzPlate { get; set; }
            public decimal ZdravSolidIzPlate { get; set; }
            public decimal PorezNaPlatuOsnov { get; set; }
            public decimal PoreznaPlatu { get; set; }
        }
        public List<DoprinosiInfo> DoprinosiLista { get; set; }
    }
}