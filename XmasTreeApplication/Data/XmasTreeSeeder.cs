using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XmasTreeApplication.Common.Entities;

namespace XmasTreeApplication.Data
{
    public class XmasTreeSeeder
    {
        private readonly XmasTreeContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public XmasTreeSeeder(XmasTreeContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            StoreUser user = await _userManager.FindByEmailAsync("andy.t.malone@gmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    UserName = "andy.t.malone@gmail.com",
                    FirstName = "Andrew",
                    LastName = "Malone",
                    Email = "andy.t.malone@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "P0lar1s!117");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }
            }

            if (!_ctx.Products.Any())
            {
                // Need to create sample data
                var productFilePath = Path.Combine(_hosting.ContentRootPath, "Data/product.json");
                var customerFilePath = Path.Combine(_hosting.ContentRootPath, "Data/customer.json");

                var productJson = File.ReadAllText(productFilePath);
                var customerJson = File.ReadAllText(customerFilePath);

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(productJson);
                var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(customerJson);
                _ctx.Products.AddRange(products);
                _ctx.Customers.AddRange(customers);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };
                }
                _ctx.SaveChanges();
            }
        }
    }
}