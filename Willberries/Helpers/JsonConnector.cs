using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Willberries.Enities;
using System.IO;

namespace Willberries.Helpers
{
    class JsonConnector
    {
        public static void ImportJson(string pathToFile) 
        {
            if (File.Exists(pathToFile))
            {
                var jsonText = File.ReadAllText(pathToFile);
                var jsonData = JsonConvert.DeserializeObject<JsonData>(jsonText);

                using (var context = new AppDbContext()) 
                {
                    if(jsonData.DeliveryMethods != null)
                    {
                        foreach (var deliveryMehtod in jsonData.DeliveryMethods) 
                        {
                            var entity = new DeliveryMethod();
                            entity.Method = deliveryMehtod.Method;
                            entity.Amount = deliveryMehtod.Amount;

                            context.DeliveryMethods.Add(deliveryMehtod);
                        }

                        context.SaveChanges();
                    }

                    if (jsonData.Customers != null)
                    {
                        foreach (var customer in jsonData.Customers) 
                        {
                            var entity = new Customer();
                            entity.Code = customer.Code;
                            entity.Title = customer.Title;
                            entity.Address = customer.Address;
                            entity.Phone = customer.Phone;
                            entity.Delegate = customer.Delegate;

                            context.Customers.Add(entity);
                        }

                        context.SaveChanges();
                    }

                    if (jsonData.Products != null) 
                    { 
                        foreach (var product in jsonData.Products) 
                        {
                            var entity = new Product();
                            entity.Title = product.Title;
                            entity.Description = product.Description;
                            entity.Code = product.Code;
                            entity.Price = product.Price;

                            if (product.DeliveryMethod != null) 
                            {
                                var deliveryMethod = context.DeliveryMethods.FirstOrDefault(d => d.Method == product.DeliveryMethod.Method);
                                if (deliveryMethod != null)
                                {
                                    entity.DeliveryMethod = deliveryMethod;
                                    context.Products.Add(entity);
                                }
                            }
                    
                        }

                        context.SaveChanges();
                    }

                    if (jsonData.Orders != null)
                    {
                        foreach (var order in jsonData.Orders)
                        {
                            if (order.Customer != null && order.Product != null)
                            {
                                var entity = new Order();
                                if (order.Customer.Title != null && order.Product.Title != null)
                                {
                                    var customer = context.Customers.FirstOrDefault(c => c.Title == order.Customer.Title);
                                    var product = context.Products.FirstOrDefault(p => p.Title == order.Product.Title);

                                    if (customer != null && product != null)
                                    {
                                        entity.Customer = customer;
                                        entity.Product = product;
                                        entity.Quantity = order.Quantity;
                                        entity.Date = order.Date;

                                        context.Orders.Add(entity);
                                    }
                                }
                            }
                        }

                        context.SaveChanges();
                    }
                }
            }
            else 
            {
                throw new FileNotFoundException("Файл для импорта не найден");
            }
        }
    }

    class JsonData 
    {
        public DeliveryMethod[] DeliveryMethods { get; set; }
        public Customer[] Customers { get; set; }
        public Product[] Products { get; set; }
        public Order[] Orders { get; set; }
    }
}
