using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Pacijent:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public DateTime? DatumRegistracije { get; set; }
        public string AktivacijskiHash { get; set; }
        public bool IsPotvrdjen { get; set; }
        public int? OpstinaRodzenjaId { get; set; }
        public Opstina OpstinaRodzenja { get; set; }
        public int? OpstinaPrebivalistaId { get; set; }
        public Opstina OpstinaPrebivalista { get; set; }
        public int? KrvnaGrupaId { get; set; }
        public KrvnaGrupa KrvnaGrupa { get; set; }
        public Korisnici Korisnici { get; set; }
        public int KlinikaId { get; set; }
        public Klinika Klinika { get; set; }
    }
}
