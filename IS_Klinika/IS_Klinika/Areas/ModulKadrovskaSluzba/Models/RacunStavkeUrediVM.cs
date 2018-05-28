using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Models
{
    public class RacunStavkeUrediVM
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public int Kolicina { get; set; }
        public int RacunId { get; set; }
        public int ProizvodId { get; set; }
        public int PDVStopeId { get; set; }

        public List<SelectListItem> ProizvodiLista { get; set; }
        public List<SelectListItem> PDVStopeList { get; set; }

    }
}