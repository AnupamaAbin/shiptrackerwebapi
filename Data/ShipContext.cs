using WebAPIShipManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPIShipManagement.Data
{
    public class ShipContext : DbContext
    {
        public ShipContext(DbContextOptions<ShipContext> options) : base(options)
        {
        }
        public DbSet<ShipModel> Ships { get; set; }
        public DbSet<PortModel> Ports { get; set; }
    }  
}
