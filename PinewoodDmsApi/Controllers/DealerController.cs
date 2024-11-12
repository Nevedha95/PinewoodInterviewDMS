using Microsoft.AspNetCore.Mvc;
using PinewoodDmsApi.Models;

namespace PinewoodDmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : Controller
    {
        private static List<Dealer> dealers = new List<Dealer>
        {
            new Dealer { Id = 1, Name = "ABC Motors", Location = "1 oxford street", ContactNumber = "123-456-7890", Email = "Motors@gm.com" },
            new Dealer { Id = 2, Name = "Coventry Auto", Location = "7 daber street", ContactNumber = "987-654-3210", Email = "coventry@gm.com" }
        };

        // GET: api/dealer
        [HttpGet]
        public ActionResult<IEnumerable<Dealer>> GetDealers()
        {
            return Ok(dealers);  // Returns the list of dealers
        }

        // GET: api/dealer/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Dealer>> GetDealer(int id)
        {
            var dealer = dealers.FirstOrDefault(d => d.Id == id);
            if (dealer == null)
            {
                return NotFound();  // Returns 404 if dealer is not found
            }

            return Ok(dealer);  // Returns the dealer
        }
        // POST: api/dealer
        [HttpPost]
        public ActionResult<IEnumerable<Dealer>> Create([FromBody] Dealer dealer)
        {
            if (dealer == null)
            {
                return BadRequest("Dealer data is invalid.");
            }

            // Simulate adding a new dealer with hardcoded ID
            dealer.Id = dealers.Max(d => d.Id) + 1;
            //foreach (var vehicle in dealer.Vehicles)
            //{
            //    vehicle.Id = vehicle.Id + 1;// Generate a new ID for each vehicle
            //    vehicle.Dealer.Id = dealer.Id;
            //    dealer.Vehicles.Add(vehicle);
            //}
            dealers.Add(dealer);

            return CreatedAtAction(nameof(GetDealer), new { id = dealer.Id }, dealer); // Returns 201 Created
        }

        // PUT: api/dealer/5
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Dealer dealer)
        {
            if (dealer == null || dealer.Id != id)
            {
                return BadRequest("Dealer data is invalid or ID mismatch.");
            }

            var existingDealer = dealers.FirstOrDefault(d => d.Id == id);
            if (existingDealer == null)
            {
                return NotFound();  // Returns 404 if dealer does not exist
            }

            // Update the dealer's details
            existingDealer.Name = dealer.Name;
            existingDealer.Location = dealer.Location;
            existingDealer.ContactNumber = dealer.ContactNumber;

            return NoContent();  // Returns 204 No Content on successful update
        }

    }
}
