namespace WebAPIShipManagement.Models
{
    public class ShipModel
    {
        public int id { get; set; }
        public string shipname { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public decimal velocity { get; set; }

    }
   
}
