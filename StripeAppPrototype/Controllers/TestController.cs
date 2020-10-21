using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StripeAppPrototype.Models;
using StripeAppPrototype.Entities;
using StripeAppPrototype.Services;

namespace StripeAppPrototype.Controllers
{
    public class TestController : Controller
    {
        private readonly BusinessService _service;
        private readonly StripeDataContext _db;

        public TestController(BusinessService service, StripeDataContext db)
        {
            _service = service;
            _db = db;
        }
        
        public IActionResult Index()
        {
            var model = new TestModel
            {
                Name = "Test"
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(TestModel model)
        {
            //var product = new Product
            //{
            //    Name = "Product 1"
            //};

            //var response = _service.CreateProduct(product);
            //product.Id = response.id;
            //_db.Product.Add(product);
            //_db.SaveChanges();

            //var price = new Price
            //{
            //    Amount = 50,
            //    ProductId = "prod_IFBXVCJcTIUnsk",
            //    Currency = "usd",
            //    Nickname = "Primary"
            //};

            //var response = _service.CreatePrice(price);
            //price.Id = response.id;
            //_db.Prices.Add(price);
            //_db.SaveChanges();
            //var response = _service.CreateInvoiceItem("cus_IEuw9XTVoO0eMW", "price_1HehEOIarr7Ydt676Dac6RCP");
            //var response = _service.CreateInvoice("cus_IEuw9XTVoO0eMW");
            //var amount = _service.GetCustomerBalance("cus_IEuw9XTVoO0eMW");


            return RedirectToAction("Index", "Home");

        }
    }
}
