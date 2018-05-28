using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Osiguranje:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string NazivPoslodavca { get; set; }
        public string Adresa { get; set; }
        public int OpstinaId { get; set; }
        public Opstina Opstina { get; set; }
        public string LicniBrOsig { get; set; }
        public string RegBr { get; set; }
        public string Zajednica { get; set; }
        public string RadnoMjesto { get; set; }
        public DateTime? OsiguranOd { get; set; }
        public DateTime? OsiguranDo { get; set; }
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}
