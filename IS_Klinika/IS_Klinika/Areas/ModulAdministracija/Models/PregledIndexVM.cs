using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class PregledIndexVM
    {
        public class PregledInfo 
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Opis { get; set; }
            public string HistorijaBolesti { get; set; }
            public bool Zavrsen { get; set; }
            public int PacijentId { get; set; }
            public string PacijentNaziv { get; set; }
            public int zaposlenikId { get; set; }
            public string zaposlenikNaziv { get; set; }
            public DateTime datumPregleda { get; set; }
        }

        public List<PregledInfo> PregledLista { get; set; }
    }
}