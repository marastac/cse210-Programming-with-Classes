using System;
using System.Collections.Generic;

namespace EncapsulationOnlineOrdering
{
    class Product
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int productId, double price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public double GetTotalCost()
        {
            return Price * Quantity;
        }
    }

    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }

        public Address(string street, string city, string stateProvince, string country)
        {
            Street = street;
            City = city;
            StateProvince = stateProvince;
            Country = country;
        }

        public bool IsInUSA()
        {
            return Country == "USA";
        }

        public string GetFullAddress()
        {
            return $"{Street}, {City}, {StateProvince}, {Country}";
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Customer(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public bool IsInUSA()
        {
            return Address.IsInUSA();
        }
    }

    class Order
    {
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }

        public Order(List<Product> products, Customer customer)
        {
            Products = products;
            Customer = customer;
        }

        public double CalculateTotalPrice()
        {
            double total = 0;
            foreach (var product in Products)
            {
                total += product.GetTotalCost();
            }

            // Shipping cost based on customer location
            return total + (Customer.IsInUSA() ? 5 : 35);
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in Products)
            {
                label += $" - {product.Name}, Product ID: {product.ProductId}\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{Customer.Name}\n{Customer.Address.GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "City1", "State1", "USA");
            Customer customer1 = new Customer("Customer1", address1);

            Address address2 = new Address("456 Elm St", "City2", "State2", "Canada");
            Customer customer2 = new Customer("Customer2", address2);

            List<Product> products1 = new List<Product>()
            {
                new Product("Product1", 1, 10.50, 2),
                new Product("Product2", 2, 20.75, 1)
            };

            List<Product> products2 = new List<Product>()
            {
                new Product("Product3", 3, 15.25, 3),
                new Product("Product4", 4, 30.00, 1)
            };

            Order order1 = new Order(products1, customer1);
            Order order2 = new Order(products2, customer2);

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total price: ${order1.CalculateTotalPrice()}");

            Console.WriteLine();

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total price: ${order2.CalculateTotalPrice()}");
        }
    }
}
