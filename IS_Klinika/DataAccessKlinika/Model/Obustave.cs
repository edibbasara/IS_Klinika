using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Obustave:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public decimal Iznos { get; set; }
        public decimal RataIznos { get; set; }
        public int BrojRata { get; set; }
        public DateTime? DatumIzdavanja { get; set; }
        public DateTime? DatumPrestanka { get; set; }
        public bool Aktivan { get; set; }
        public int ZaposlenikId { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
        public int VrstaObustaveId { get; set; }
        public VrstaObustave VrstaObustave { get; set; }
    }
}
