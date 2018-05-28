using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Klinika.Areas.ModulAdministracija.Models
{
    public class PregledUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string Opis { get; set; }
        public string HistorijaBolesti { get; set; }
    }
}