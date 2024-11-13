using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PinewoodDmsMVC.Models;
using System.Net.Http.Json;

namespace PinewoodDmsMVC.Controllers
{
    public class DealerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiUrl = "https://localhost:5033/api/Dealer"; 

        public DealerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        // GET: /Dealer/Index
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<List<Dealer>>(ApiUrl);

            return View(response);  // Pass the list of dealers to the view
        }
        // GET: DealerMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DealerMvc/Create
        [HttpPost]
        public async Task<IActionResult> Create(Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("clientname");
                var response = await httpClient.PostAsJsonAsync(ApiUrl, dealer);  // POST the dealer to the API

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");  
                }
            }
            return View(dealer); 
        }

        // GET: DealerMvc/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetStringAsync($"{ApiUrl}/{id}"); 
            var dealer = JsonConvert.DeserializeObject<Dealer>(response);  // Deserialize the response into a Dealer object

            return View(dealer);  
        }
        // POST: DealerMvc/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.PutAsJsonAsync($"{ApiUrl}/{id}", dealer);  
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");  
                }
            }
            return View(dealer);  
        }
        public async Task<IActionResult> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("DealerClient");
            await httpClient.DeleteAsync($"{ApiUrl}/{id}");
            return RedirectToAction("Index");
        }

        // GET: /Dealer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var dealer = await httpClient.GetFromJsonAsync<Dealer>($"{ApiUrl}/{id}");

            return View(dealer);
        }
    }
}
