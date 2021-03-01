using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CallingAPIFromMVC.Models;
using CallingAPIFromMVC.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace CallingAPIFromMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        CustomerAPI _api = new CustomerAPI();
        public async Task<IActionResult> Index()
        {
            List<CustomerData> customers = new List<CustomerData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("customers");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<CustomerData>>(results);
            }
            return View(customers);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var customer = new CustomerData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"customers/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<CustomerData>(results);
            }
            return View(customer);
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(CustomerData customer)
        {
            HttpClient client = _api.Initial();

            //HTTP POST
            
            var postTask = client.PostAsJsonAsync<CustomerData>("customers", customer);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var customer = new CustomerData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"customers/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<CustomerData>(results);
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerData customer)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"customers/{customer.Id}", customer);
            response.EnsureSuccessStatusCode();

            customer = await response.Content.ReadAsAsync<CustomerData>();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {

            var customer = new CustomerData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"customers/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<CustomerData>(results);
            }
            return RedirectToAction("Index");
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}

