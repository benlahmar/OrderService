using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Domain.Models
{
    public class Composant
    {
        public int Id { get; set; }
        [NotMapped]
        public Produit? Produit { get; set; }
        public int quantite { get; set; }

        public double price { get; set; }
        public int idproduit { get; set; }
        [JsonIgnore]
        public Command? command { get; set; }

    }
}
