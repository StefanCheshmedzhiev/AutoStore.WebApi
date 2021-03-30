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

    }
}
