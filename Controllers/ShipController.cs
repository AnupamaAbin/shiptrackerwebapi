using WebAPIShipManagement.Models;
using WebAPIShipManagement.Data;
using WebAPIShipManagement.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace WebAPIShipManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly ShipContext _context;

        public ShipController(ShipContext context)       
        {
            _context = context;

        }
                
        // GET: api/Ship : Get all ship details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipDTO>>> GetShips()

        {
            return await _context.Ships
            .Select(x => ItemToDTO(x))
            .ToListAsync();
        }

        // GET: api/Ship/5 : Find the closest port to a ship with estimated arrival time to the port.
        [HttpGet("nearestPort/{shipId}")]
        public async Task<ActionResult<string>> GetShipModel(int shipId)
        {
           
            var shipModel = await _context.Ships.FindAsync(shipId);

            var portData = await _context.Ports.ToListAsync();

            string nearestPortDetails = PortService.CalcClosetPort(shipModel,portData);
          
            return nearestPortDetails;
                      
        }

        // PUT: api/Ship/5 : update existing ship details /name/velocity/geolocation
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipModel(int id, ShipDTO shipDTO)
        {
            if (id != shipDTO.id)
            {
                return BadRequest();
            }

            var shipDetails = await _context.Ships.FindAsync(id);
            if (shipDetails == null)
            {
                return NotFound();
            }
            shipDetails.shipname = shipDTO.shipname;
            shipDetails.longitude = shipDTO.longitude;
            shipDetails.latitude = shipDTO.latitude;
            shipDetails.velocity = shipDTO.velocity;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ShipModelExists(id))
            {

                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Ship : add ships to the system.
        [HttpPost]
        public async Task<ActionResult<ShipModel>> PostShipModel(ShipModel shipModel)
        {
            _context.Ships.Add(shipModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShips", new { id = shipModel.id }, shipModel);
        }


        private bool ShipModelExists(int id)
        {
            return _context.Ships.Any(e => e.id == id);
        }
        private static ShipDTO ItemToDTO(ShipModel ships) =>
        new ShipDTO
        {
            id = ships.id,
            shipname = ships.shipname,
            longitude = ships.longitude,
            latitude = ships.latitude,
            velocity = ships.velocity
        };

      
    }
}

