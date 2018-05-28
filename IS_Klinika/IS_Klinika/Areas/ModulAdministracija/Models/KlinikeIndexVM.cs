using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class KlinikeIndexVM
    {
        public class KlinikaInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Sifra { get; set; }
            public string Naziv { get; set; }
            public string Vrsta { get; set; }
            public string Adresa { get; set; }
            public string IdBroj { get; set; }
            public string PDVbroj { get; set; }
            public string ZdravInstitBr { get; set; }
            public double KoefRPV { get; set; }
            public double KoefPR { get; set; }
            public double KoefGO { get; set; }
            public double KoefBD42D { get; set; }
            public double KoefBP42D { get; set; }
            public double KoefRN { get; set; }
            public double KoefNS { get; set; }
            public double KoefNR { get; set; }
            public double KoefRDP { get; set; }
            public int OpstinaId { get; set; }
            public String OpstinaNaziv { get; set; }
        }
        public List<KlinikaInfo> ListaKlinika { get; set; }


    }
}