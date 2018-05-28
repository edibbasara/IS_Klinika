using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Recept:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public string Upotreba { get; set; }
        public int DijagnozaId { get; set; }
        public Dijagnoza Dijagnoza { get; set; }
    }
}
