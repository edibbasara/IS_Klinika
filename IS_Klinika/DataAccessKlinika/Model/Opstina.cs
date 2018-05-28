using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Opstina:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string PTT { get; set; }
        public string Naziv { get; set; }
    }
}
