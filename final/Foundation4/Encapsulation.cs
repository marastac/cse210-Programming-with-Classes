using System;
using System.Collections.Generic;

namespace OnlineOrderingEncapsulation
{
    class Product
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public double GetTotalCost()
        {
            return Price * Quantity;
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public bool IsInUSA()
        {
            return Address.IsInUSA();
        }
    }

    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }

        public bool IsInUSA()
        {
            return Country == "USA";
        }
    }

    class Order
    {
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (var product in Products)
            {
                totalPrice += product.GetTotalCost();
            }

            if (Customer.IsInUSA())
            {
                return totalPrice + 5; // USA shipping cost
            }
            else
            {
                return totalPrice + 35; // International shipping cost
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product { Name = "Product 1", ProductId = 1, Price = 10, Quantity = 2 };
            Product product2 = new Product { Name = "Product 2", ProductId = 2, Price = 15, Quantity = 1 };

            Customer customer = new Customer
            {
                Name = "John Doe",
                Address = new Address { Street = "123 Main St", City = "Anytown", StateProvince = "CA", Country = "USA" }
            };

            Order order = new Order { Products = new List<Product> { product1, product2 }, Customer = customer };

            Console.WriteLine($"Total Price: ${order.CalculateTotalPrice()}");
        }
    }
}
