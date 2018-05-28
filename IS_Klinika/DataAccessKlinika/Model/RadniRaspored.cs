using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class RadniRaspored:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public DateTime? DatumOD { get; set; }
        public DateTime? DatumDO { get; set; }
        public int ZaposlenikID { get; set; }
        public Zaposlenik Zaposlenik {get;set;}
        public int SmjenaId { get; set; }
        public Smjena Smjena { get; set; }
    }
}
