﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessKlinika.Helper
{
    interface IEntity
    {
        int Id { get; set; }
        bool Valid { get; set; }    
    }
}
