using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Models
{
    public class Composant
    {
        public int Id { get; set; } 
        public Produit Produit { get; set; }
        public int quantite { get; set; }

        public double price { get; set; }
        public int idproduit { get; set; }
        public Command command { get; set; }

    }
}
