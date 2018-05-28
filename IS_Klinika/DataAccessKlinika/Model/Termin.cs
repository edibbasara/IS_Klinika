using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Termin:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string Sati { get; set; }
        public string Minuti { get; set; }
        public int SmjenaId { get; set; }
        public Smjena Smjena { get; set; }
    }
}
