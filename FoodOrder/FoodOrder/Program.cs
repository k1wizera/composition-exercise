using FoodOrder.Entities;
using FoodOrder.Entities.Enums;
using System;
using System.Globalization;

namespace FoodOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client Data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter {i} item data:");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantityProduct = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Product product = new Product(nameProduct, priceProduct);
                OrderItem orderItem = new OrderItem(quantityProduct, priceProduct, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
