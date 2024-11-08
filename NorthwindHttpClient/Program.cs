using NorthwindHttpClient.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;

namespace NorthwindHttpClient
{
    internal class Program
    {
        public const string WEB_API = "http://localhost:5101";

        static async Task Main(string[] args)
        {
            // using ist wichtig da HttpClient ein IDisposable ist
            using var client = new HttpClient();
            client.BaseAddress = new Uri(WEB_API);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var customer = new Customer
            {
                CustomerId = "PPEDV",
                CompanyName = "PPEDV AG",
                ContactName = "Max Mustermann",
                ContactTitle = "CEO",
                Address = "Musterstraße 1",
                City = "Musterstadt",
                Region = "Bayern",
                PostalCode = "12345",
                Country = "Deutschland",
                Phone = "0123456789",
                Fax = "0123456789"
            };

            // Post entspricht dem Create 
            var response = await client.PostAsync("/api/customers", JsonContent.Create(customer));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Neuer Kunde {customer.CompanyName} wurde erzeugt.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } 
            else
            {
                await HandleFailedRequest(response);
            }

            // Get entspricht dem Read
            response = await client.GetAsync("/api/customers/" + customer.CustomerId);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Customer>();
                Console.WriteLine($"{result?.CompanyName} gelesen.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                await HandleFailedRequest(response);
            }

            // Put entspricht dem Update
            customer.CompanyName = "PPEDV AG - Neu";
            response = await client.PutAsync("/api/customers/" + customer.CustomerId, JsonContent.Create(customer));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{customer.CompanyName} aktualisiert.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                await HandleFailedRequest(response);
            }

            // Delete entspricht Delete
            response = await client.DeleteAsync("/api/customers/" + customer.CustomerId);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{customer.CompanyName} gelöscht.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                await HandleFailedRequest(response);
            }
        }

        private static async Task HandleFailedRequest(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception($"{response.ReasonPhrase}\n{content}");
        }
    }
}
