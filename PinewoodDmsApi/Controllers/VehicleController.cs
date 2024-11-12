using Microsoft.AspNetCore.Mvc;
using PinewoodDmsApi.Models;

namespace PinewoodDmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        //private static List<Dealer> dealers = new List<Dealer>
        //{
        //    new Dealer { Id = 1, Name = "Dealer One", Location = "New York" },
        //    new Dealer { Id = 2, Name = "Dealer Two", Location = "Los Angeles" }
        //};

        private static List<Vehicle> vehicles = new List<Vehicle>
        {
                new Vehicle
                {
                    VehicleId = 1,
                    VIN = "1HGCM82633A123456",
                    Make = "Honda",
                    Model = "Accord",
                    Year = 2020,
                    Color = "Black",
                    Mileage = 15000,
                    Price = 20000,
                    Transmission = "Automatic",
                    FuelType = "Gasoline",
                    Description = "Well-maintained sedan with low mileage.",
                    Id = 2
                },
                new Vehicle {
                VehicleId = 2,
                    VIN = "1HGCM82633A123457",
                    Make = "Ford",
                    Model = "Ikon",
                    Year = 2012,
                    Color = "Red",
                    Mileage = 4000,
                    Price = 50000,
                    Transmission = "Automatic",
                    FuelType = "Gasoline",
                    Description = "Well-maintained sedan with low mileage.",
                    Id=1

                },
                 new Vehicle {
                VehicleId = 3,
                    VIN = "1HGCM82633A123458",
                    Make = "hyundai",
                    Model = "i10",
                    Year = 2016,
                    Color = "blue",
                    Mileage = 2000,
                    Price = 90000,
                    Transmission = "Manual",
                    FuelType = "Petrol",
                    Description = "Well-maintained sedan with low mileage.",
                     Id=1

                },
                  new Vehicle {
                VehicleId = 4,
                    VIN = "1HGCM82633A123459",
                    Make = "Toyota",
                    Model = "Innova",
                    Year = 2020,
                    Color = "Silver",
                    Mileage = 2000,
                    Price = 100000,
                    Transmission = "Automatic",
                    FuelType = "Diesel",
                    Description = "Well-maintained sedan with low mileage.",
                    Id=2

                }
        };

        // GET: api/vehicles
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles()
        {
            return Ok(vehicles);
        }
        // GET: api/dealer/5
        [HttpGet("{id}")]
        public ActionResult<Dealer> GetVehicle(int id)
        {
            var dealer = vehicles.FirstOrDefault(d => d.VehicleId == id);
            if (dealer == null)
            {
                return NotFound();  // Returns 404 if dealer is not found
            }

            return Ok(dealer); 
        }
        [HttpPost]
        public ActionResult<IEnumerable<Vehicle>> Create([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Dealer data is invalid.");
            }
            // Simulate adding a new dealer with hardcoded ID

            vehicle.VehicleId = vehicle.VehicleId + 1;

            //foreach (var vehicle in dealer.Vehicles)
            //{
            //    vehicle.Id = vehicle.Id + 1;// Generate a new ID for each vehicle
            //    vehicle.Dealer.Id = dealer.Id;
            //    dealer.Vehicles.Add(vehicle);
            //}
            vehicles.Add(vehicle);

            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.VehicleId }, vehicle); // Returns 201 Created
        }
        [HttpGet]
        [Route("listbydealer/{dealerId}")]
        public ActionResult<Dealer> ListByDealer(int id)
        {
            var vehicle = vehicles.Where(v => v.Id == id).ToList();
            if (vehicle == null)
            {
                return NotFound();  // Returns 404 if dealer is not found
            }

            return Ok(vehicle);
        }

    }
}
