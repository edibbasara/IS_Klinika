using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Zaposlenik:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsKadrovskoOsoblje { get; set; }
        public bool IsMedicinskoOsoblje { get; set; }
        public bool IsDoktor { get; set; }
        public string Banka { get; set; }
        public string Konto { get; set; }
        public double KoefLO { get; set; }
        public string PIOregBr { get; set; }
        public string PIOdjelBr { get; set; }
        public string MinuliRad { get; set; }
        public DateTime PocetakRada { get; set; }
        public DateTime? KrajRada { get; set; }
        public string JMBG { get; set; }
        public string LKbr { get; set; }
        public int? OpstinaRodzenjaId { get; set; }
        public Opstina OpstinaRodzenja { get; set; }
        public int? OpstinaPrebivalistaId { get; set; }
        public Opstina OpstinaPrebivalista { get; set; }
        public int KlinikaId { get; set; }
        public Klinika Klinika { get; set; }
        public int RadnoMjestoId { get; set; }
        public RadnoMjesto RadnoMjesto { get; set; }
        public Korisnici Korisnici { get; set; }
    }
}
