using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price{ get; set; }
        public string Manufacturer { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public string ArtId { get; set; }

    }
}

