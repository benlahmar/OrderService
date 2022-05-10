﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Models
{
    public class Command
    {
        public int Id { get; set; }
        public DateTime date { get; set; }

        public IEnumerable<Composant> composants { get; set; }
        public int idclient { get; set; }

        
        public Client Client { get; set; }
    }
}
