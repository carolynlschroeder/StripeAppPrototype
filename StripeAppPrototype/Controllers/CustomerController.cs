using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe;
using StripeAppPrototype.Dtos;
using StripeAppPrototype.Entities;
using StripeAppPrototype.Models;
using StripeAppPrototype.Services;
using Customer = StripeAppPrototype.Entities.Customer;

namespace StripeAppPrototype.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _config;
        private readonly BusinessService _businessServices;
        private readonly StripeDataContext _db;

        public CustomerController(
           BusinessService businessServices, StripeDataContext db, IConfiguration config)
        {
            _businessServices = businessServices;
            _db = db;
            _config = config;
        }

        public IActionResult AddPaymentMethod(string email = "")
        {
            var model = new PaymentMethodModel()
            {
                StripePublishableKey = _config.GetSection("Stripe")["PublishableKey"]
            };
            if (string.IsNullOrEmpty(email))
            {
                model.Email = email;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AddPaymentMethod(PaymentMethodModel model)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Email == model.Email);
            bool isPaymentPrimary = false;
            if (customer == null)
            {
                customer = new StripeAppPrototype.Entities.Customer {Email = model.Email};
                CreateCustomerResponse customerResponse = _businessServices.CreateCustomer(customer);
                if (String.IsNullOrEmpty(customerResponse.id))
                {
                    ModelState.AddModelError("", "Could not add customer method");
                    return View(model);
                }

                customer.Id = customerResponse.id;
                isPaymentPrimary = true;
                _db.Customers.Add(customer);
            }

            var paymentMethod = new StripeAppPrototype.Entities.PaymentMethod { Id = model.PaymentMethodId, CustomerId = customer.Id, Description = model.Description, IsPrimary = isPaymentPrimary };
            _db.PaymentMethods.Add(paymentMethod);

            AttachPaymentMethodResponse attachPaymentMethodResponse =
                _businessServices.AttachPaymentMethodToCustomer(customer.Id, paymentMethod.Id);

            if (isPaymentPrimary)
            {
 
                UpdateCustomerResponse updateCustomerResponse = _businessServices.UpdateCustomer(customer.Id, paymentMethod.Id);
                if (String.IsNullOrEmpty(updateCustomerResponse.id))
                {
                    ModelState.AddModelError("", "Could not add primary");
                    return View(model);
                }
            }

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        public IActionResult PaymentMethods()
        {
            return View();
        }

        public JsonResult GetPaymentMethodsForCustomer(string email)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Email == email);
            var list = GetPaymentsRets(customer.Id);
            return Json(new {paymentMethods = list});
        }

        private List<GetPaymentsRet> GetPaymentsRets(string customerId)
        {
            var paymentMethods = _db.PaymentMethods.Where(p => p.CustomerId == customerId);
            var list = new List<GetPaymentsRet>();
            foreach (var p in paymentMethods)
            {
                var r = new GetPaymentsRet
                {
                    Description = p.Description,
                    IsPrimaryName = p.IsPrimary ? "Yes" : "No",
                    PaymentMethodId = p.Id
                };

                list.Add(r);
            }

            return list;
        }

        public  class GetPaymentsRet
        {
            public string Description { get; set; }
            public string IsPrimaryName { get; set; }
            public string PaymentMethodId { get; set; }
        }

        public JsonResult MakePrimary(string id)
        {
            var paymentMethod = _db.PaymentMethods.FirstOrDefault(p => p.Id == id);
            var customerId = paymentMethod.CustomerId;
            UpdateCustomerResponse updateCustomerResponse = _businessServices.UpdateCustomer(customerId, id);
           
            if (!string.IsNullOrEmpty(updateCustomerResponse.id))
            {
                paymentMethod.IsPrimary = true;
                _db.Entry<StripeAppPrototype.Entities.PaymentMethod>(paymentMethod).State = EntityState.Modified;
                var restOfMethods = _db.PaymentMethods.Where(p => p.Id != id && p.CustomerId == customerId);
                foreach (var p in restOfMethods)
                {
                    p.IsPrimary = false;
                    _db.Entry<StripeAppPrototype.Entities.PaymentMethod>(p).State = EntityState.Modified;
                }
                
                _db.SaveChanges();
                var list = GetPaymentsRets(customerId);
                return Json(new {message = "Success",paymentMethods = list });
            }
            return Json(new { message = "Failed" });
        }

        public JsonResult DetachPaymentMethod(string id)
        {
            DetachPaymentMethodResponse detachPaymentMethodResponse = _businessServices.DetachPaymentMethod(id);
            if (!string.IsNullOrEmpty(detachPaymentMethodResponse.id))
            {
                var paymentMethod = _db.PaymentMethods.FirstOrDefault(p => p.Id == id);
                var customerId = paymentMethod.CustomerId;
                _db.PaymentMethods.Remove(paymentMethod);
                _db.SaveChanges();
                var list = GetPaymentsRets(customerId);
                return Json(new { message = "Success", paymentMethods = list });
            }
            return Json(new { message = "Failed" });
        }

    }
}
