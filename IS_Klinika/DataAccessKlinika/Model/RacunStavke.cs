using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class RacunStavke
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public int Kolicina { get; set; }
        public int RacunId { get; set; }
        public Racun Racun { get; set; }
        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public int PDVStopeId { get; set; }
        public PDVStope PDVStope { get; set; }
    }
}
