using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Obracun:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string Mjesec { get; set; }
        public string Godina { get; set; }
        public int RPV { get; set; }
        public int PR { get; set; }
        public int GO { get; set; }
        public int BD42D { get; set; }
        public int BP42D { get; set; }
        public int DP { get; set; }
        public int RN { get; set; }
        public int NS { get; set; }
        public int NR { get; set; }
        public int RDP { get; set; }
        public int ZaposlenikId { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
        public int DoprinosiId { get; set; }
        public Doprinosi Doprinosi { get; set; }
        public DateTime? PeriodOD { get; set; }
        public DateTime? PeriodDO { get; set; }
        public DateTime DatumObracuna { get; set; }
        public ObracunDoprinosi ObracunDoprinosi { get; set; }
    }
}
