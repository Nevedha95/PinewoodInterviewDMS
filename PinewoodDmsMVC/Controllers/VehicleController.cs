using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PinewoodDmsMVC.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace PinewoodDmsMVC.Controllers
{
    public class VehicleController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:5033/api/Vehicle";
        public VehicleController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("clientname");
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Vehicle>>(ApiUrl);

            return View(response);
        }
       
        public ActionResult Create(int dealerId)
        {
            var vehicle = new Vehicle
            {
                Id = dealerId // Set the dealer ID in the model itself
            };

            return View(vehicle);
        }
        // POST: DealerMvc/Create
        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync(ApiUrl, vehicle);  // POST the dealer to the API

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { dealerId = vehicle.Id });
                }
            }
            return View(vehicle);  // Return the same view if there is an error or validation fails
        }
        public async Task<IActionResult> ListByDealer(int id)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}/listbydealer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var vehiclesJson = await response.Content.ReadAsStringAsync();
               var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(vehiclesJson);
                ViewBag.Id = id;
                return View(vehicles);
            }

            ViewBag.VehicleId = id;
          return View(new List<Vehicle>());
        }
    }
}
