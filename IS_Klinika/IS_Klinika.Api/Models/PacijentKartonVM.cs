using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Api.Models
{
    public class PacijentKartonVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string Opis { get; set; }
        public string HistorijaBolesti { get; set; }
        public string DijagnozaOpis { get; set; }
        public int DijagnozaId { get; set; }


        public class ReceptInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string Naziv { get; set; }
            public string Vrsta { get; set; }
            public string Upotreba { get; set; }
            public int DijagnozaId { get; set; }
        }

        public class OsiguranjeInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public string NazivPoslodavca { get; set; }
            public string Adresa { get; set; }
            public string OpstinaNaziv { get; set; }
            public string LicniBrOsig { get; set; }
            public string RegBr { get; set; }
            public string Zajednica { get; set; }
            public string RadnoMjesto { get; set; }
            public DateTime? OsiguranOd { get; set; }
            public DateTime? OsiguranDo { get; set; }
            public int PacijentId { get; set; }
        }

        public class RacunInfo
        {
            public int Id { get; set; }
            public bool Valid { get; set; }
            public decimal PDVIznosUkupno { get; set; }
            public decimal IznosUkupno { get; set; }
            public decimal IznosBezPDVUkupno { get; set; }
            public decimal Popust { get; set; }
            public DateTime Datum { get; set; }
            public int PregledId { get; set; }

            public class RacunStavkaInfo
            {
                public int Id { get; set; }
                public bool Valid { get; set; }
                public int Kolicina { get; set; }
                public int RacunId { get; set; }
                public int ProizvodId { get; set; }
                public string NazivProizvod { get; set; }
                public decimal Cijena { get; set; }
                public int PDVStopeId { get; set; }
                public decimal PDVstopa { get; set; }
                public decimal IznosBezPDV { get; set; }
                public decimal IznosSaPDV { get; set; }
                public decimal IznosPDV { get; set; }
            }

            public List<RacunStavkaInfo> RacunStavkaList { get; set; }
        }

        public List<RacunInfo> RacunList { get; set; }
        public List<OsiguranjeInfo> OsiguranjeList { get; set; }
        public List<ReceptInfo> ReceptList { get; set; }
    }
}