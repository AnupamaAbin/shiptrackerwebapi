using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIShipManagement.Models
{
    public class ShipDTO
    {
        public int id { get; set; }
        public string shipname { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public decimal velocity { get; set; }
    }
}
