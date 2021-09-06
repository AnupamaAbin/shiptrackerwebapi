using System.Collections.Generic;
namespace WebAPIShipManagement.Models
{
    public class PortModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
    }
    
}
