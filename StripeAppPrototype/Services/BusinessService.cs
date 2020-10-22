using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Stripe;
using Stripe.Issuing;
using StripeAppPrototype.Dtos;
using Customer = StripeAppPrototype.Entities.Customer;
using Price = StripeAppPrototype.Dtos.Price;
using Product = StripeAppPrototype.Entities.Product;

namespace StripeAppPrototype.Services
{
    public class BusinessService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public BusinessService(IConfiguration config)
        {
            _config = config;
            _client = ClientWithAuthHeaders();
        }

        private HttpClient ClientWithAuthHeaders()
        {
            HttpClient client = new HttpClient(); ;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                string svcCredentials =
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(_config.GetSection("Stripe")["SecretKey"]));
            client.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Basic", svcCredentials);

            return client;
        }

        public CreateCustomerResponse CreateCustomer(string email)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email)
            });
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync("https://api.stripe.com/v1/customers", content))
                .GetAwaiter().GetResult();

            var createCustomerResponse = new CreateCustomerResponse();

            if (response.IsSuccessStatusCode)
            {

                createCustomerResponse =
                    JsonConvert.DeserializeObject<CreateCustomerResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return createCustomerResponse;
        }


        public CreateProductResponse CreateProduct(Product product)
        {

            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", product.Name)
            });
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync("https://api.stripe.com/v1/products", content))
                .GetAwaiter().GetResult();

            var createProductResponse = new CreateProductResponse();

            if (response.IsSuccessStatusCode)
            {

                createProductResponse =
                    JsonConvert.DeserializeObject<CreateProductResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return createProductResponse;
        }

        public AttachPaymentMethodResponse AttachPaymentMethodToCustomer(string customerId, string paymentMethodId)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("customer", customerId),

            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync($"https://api.stripe.com/v1/payment_methods/{paymentMethodId}/attach", content))
                .GetAwaiter().GetResult();

            var attachPaymentMethodResponse = new AttachPaymentMethodResponse();

            if (response.IsSuccessStatusCode)
            {

                attachPaymentMethodResponse = 
                    JsonConvert.DeserializeObject<AttachPaymentMethodResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return attachPaymentMethodResponse;
        }

        public CreatePriceResponse CreatePrice(StripeAppPrototype.Entities.Price price)
        {
            //unit_amount is in cents
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("unit_amount", ((int)price.Amount * 100).ToString()),
                new KeyValuePair<string, string>("currency", price.Currency),
                new KeyValuePair<string, string>("product", price.ProductId),
                new KeyValuePair<string, string>("nickname", price.Nickname),

            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync("https://api.stripe.com/v1/prices", content))
                .GetAwaiter().GetResult();

            var createPriceResponse = new CreatePriceResponse();

            if (response.IsSuccessStatusCode)
            {

                createPriceResponse =
                    JsonConvert.DeserializeObject<CreatePriceResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return createPriceResponse;
        }


        public CreateInvoiceItemResponse CreateInvoiceItem(string customerId, string priceId, int quantity)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("customer", customerId),
                new KeyValuePair<string, string>("price", priceId),
                new KeyValuePair<string, string>("quantity", quantity.ToString())

            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync("https://api.stripe.com/v1/invoiceitems", content))
                .GetAwaiter().GetResult();

            var createInvoiceItemResponse = new CreateInvoiceItemResponse();

            if (response.IsSuccessStatusCode)
            {

                createInvoiceItemResponse =
                    JsonConvert.DeserializeObject<CreateInvoiceItemResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return createInvoiceItemResponse;
        }

       

        public CreateCustomerResponse CreateCustomer(Customer customer)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", customer.Email)

            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync("https://api.stripe.com/v1/customers", content))
                .GetAwaiter().GetResult();

            var createCustomerResponse = new CreateCustomerResponse();

            if (response.IsSuccessStatusCode)
            {

                createCustomerResponse =
                    JsonConvert.DeserializeObject<CreateCustomerResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return createCustomerResponse;
        }

        public UpdateCustomerResponse UpdateCustomer(string customerId, string paymentMethodId)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("invoice_settings[default_payment_method]", paymentMethodId)

            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync($"https://api.stripe.com/v1/customers/{customerId} ", content))
                .GetAwaiter().GetResult();

            var updateCustomerResponse = new UpdateCustomerResponse();

            if (response.IsSuccessStatusCode)
            {

                updateCustomerResponse =
                    JsonConvert.DeserializeObject<UpdateCustomerResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return updateCustomerResponse;
        }

        public DetachPaymentMethodResponse DetachPaymentMethod(string paymentMethodId)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>()

            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpResponseMessage response = (_client.PostAsync($"https://api.stripe.com/v1/payment_methods/{paymentMethodId}/detach", content))
                .GetAwaiter().GetResult();

            var detachPaymentMethodResponse = new DetachPaymentMethodResponse();

            if (response.IsSuccessStatusCode)
            {

                detachPaymentMethodResponse = JsonConvert.DeserializeObject<DetachPaymentMethodResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return detachPaymentMethodResponse;
        }

        
        //Create Draft Invoice for Customer
        public CreateInvoiceResponse CreateInvoice(string customerId)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("customer", customerId)

            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync("https://api.stripe.com/v1/invoices", content))
                .GetAwaiter().GetResult();

            var createInvoiceResponse = new CreateInvoiceResponse();

            if (response.IsSuccessStatusCode)
            {
                createInvoiceResponse =
                    JsonConvert.DeserializeObject<CreateInvoiceResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return createInvoiceResponse;
        }

        //Get Balance on Stripe Account
        public decimal GetBalance()
        {
            HttpResponseMessage response = (_client.GetAsync($"https://api.stripe.com/v1/balance"))
                .GetAwaiter().GetResult();

            decimal amount = 0;
            if (response.IsSuccessStatusCode)
            {
                 var balanceResponse = JsonConvert.DeserializeObject<BalanceResponse>(response.Content.ReadAsStringAsync().Result);
                var available = balanceResponse.available;
  
                foreach (var a in available)
                {
                    amount += a.amount;
                }
            }

            return Convert.ToDecimal(amount/100);
        }

        //Transfer an amount to an existing Bank Account Set up with Stripe
        public PayoutResponse TransferToBankAccount(decimal amount, string currency)
        {
            //Stripe requires amount in cents
            var transferAmount = ((int) amount * 100);
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("amount", transferAmount.ToString()),
                new KeyValuePair<string, string>("currency", currency)

            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = (_client.PostAsync($"https://api.stripe.com/v1/payouts", content))
                .GetAwaiter().GetResult();

            var payoutResponse = new PayoutResponse();

            if (response.IsSuccessStatusCode)
            {

                payoutResponse =
                    JsonConvert.DeserializeObject<PayoutResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return payoutResponse;
        }

        //Get Customer Balance
        public decimal GetCustomerBalance(string customerId)
        {
            var amount = 0;
            var options = new CustomerBalanceTransactionListOptions();
            var service = new CustomerBalanceTransactionService();
            StripeList<CustomerBalanceTransaction> balanceTransactions = service.List(
                customerId, options);
            foreach (var b in balanceTransactions)
            {
                amount +=  Convert.ToInt32(b.Amount);
            }

            return Convert.ToDecimal(amount / 100);
        }
    }
}
