﻿using DataAccessKlinika.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Model
{
    public class Dijagnoza:IEntity
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public string Opis { get; set; }
        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }
    }
}
