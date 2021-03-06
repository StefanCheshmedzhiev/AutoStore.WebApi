﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CallingAPIFromMVC.Helper;
using CallingAPIFromMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CallingAPIFromMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        ProductAPI _api = new ProductAPI();

        public async Task<IActionResult> Index()
        {
            List<ProductData> products = new List<ProductData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("products");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductData>>(results);
            }
            return View(products);
        }

        [HttpGet("Product/GetByProductType/{productType}")]
        public async Task<IActionResult> GetByProductType(string productType)
        {
            
            var product = new List<ProductData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"products/ProductType/{productType}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<List<ProductData>>(results);
            }
            return View(product);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var product = new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"products/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductData>(results);
            }
            return View(product);
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(ProductData product)
        {
            HttpClient client = _api.Initial();

            //HTTP POST

            var postTask = client.PostAsJsonAsync<ProductData>("products", product);
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
            var product = new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"products/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductData>(results);
            }
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductData product)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            product = await response.Content.ReadAsAsync<ProductData>();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {

            var customer = new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"products/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<ProductData>(results);
            }
            return RedirectToAction("Index");
        }
    }
}
