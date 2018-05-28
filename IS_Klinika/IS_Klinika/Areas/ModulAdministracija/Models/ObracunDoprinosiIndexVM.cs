using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class ObracunDoprinosiIndexVM
    {
            public int Id { get; set; }
            public bool Valid { get; set; }
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


            public decimal koefPIOnaPlatu { get; set; }
            public decimal koefZdravNaPlatu { get; set; }
            public decimal koefNezapFedNaPlatu { get; set; }
            public decimal koefNezapKanNaPlatu { get; set; }
            public decimal koefZdravSolidNaPlatu { get; set; }
            public decimal koefZastitaOdPrirNepNaPlatu { get; set; }
            public decimal koefPIOizPlate { get; set; }
            public decimal koefZdravIzPlate { get; set; }
            public decimal koefNezapFedIzPlate { get; set; }
            public decimal koefNezapKanIzPlate { get; set; }
            public decimal koefZdravSolidIzPlate { get; set; }
            public decimal koefPorezNaPlatuOsnov { get; set; }
            public decimal koefPoreznaPlatu { get; set; }

        
    }
}