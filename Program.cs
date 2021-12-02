using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Test_Nov_2021
{
    //Write your name here
    class Program
    {
        static void Main(string[] args)
        {

            //Part 1
            string json = apiRequest();
            dynamic i = JsonConvert.DeserializeObject(json);
            Console.WriteLine(i.age);

            //Part 2
            List<Product> products = new List<Product> {
                new Product {Id = "B091NE9K3", Price =59.96, Quantity = 5},
                new Product {Id = "B091NEGU3", Price =7.05, Quantity = 10},
                new Product {Id = "B091NEEC3", Price =6.38, Quantity = 15},
                new Product {Id = "B091NE9S3", Price =13.25, Quantity = 23},
                new Product {Id = "B091NE9K4", Price =99.96, Quantity = 2},
                new Product {Id = "B091NEGU4", Price =22.83, Quantity = 150},
                new Product {Id = "B091NEEC4", Price =19.18, Quantity = 45},
                new Product {Id = "B091NE9S4", Price =28.88, Quantity = 345},
                new Product {Id = "B091NE9K5", Price =49.99, Quantity = 589},
                new Product {Id = "B091NEGU5", Price =12.05, Quantity = 25},
            };

            /*Low stocks*/            
            List<Product> losStocks = lowStock(products);
            Console.WriteLine("\nIds los stocs");
            foreach (Product item in losStocks)
            {                
                Console.WriteLine(item.Id);
            }

            /*Average stocks*/
            double aveStocks = products.Average(x => x.Price);
            Console.WriteLine("Avg Price: $"+aveStocks);

            /*Update stock (B091NE9K4)*/
            Console.WriteLine("\nUpdated list");
            foreach (Product item in products) 
            {
                if (item.Id == "B091NE9K4 ") { item.Price = item.Price * 1.3; }
                //Console.WriteLine(item.Id + " " + item.Price);
                Console.WriteLine("{0} {1:C}", item.Id, item.Price);

            }
            


            //Part 3 
            int[] ordersIds = { 1, 2, 3, 4, 5 };
            double[] ordersValues = { 25.5, 92.5, 78.23, 12.95, 83.67 };
            string[] ordersCustomers = { "Tracy Erkut", "Arvin Aitken", "Ryan Mae", "Sherri Smith", "Adam Weller" };

            List<Order> newList = new List<Order>();
            for (int x = 0; x < ordersIds.Length; x++) 
            {
                Order item = new Order { Id = ordersIds[x], Price = ordersValues[x], Customer = ordersCustomers[x] };
                newList.Add(item);
            }

            List<Order> sortList = newList.OrderBy(x => x.Price).ToList();
            /*Display the sorted list*/
            Console.WriteLine("\n{0,-10} {1} {2}", "OrderId", "Value", "Customer");
            foreach (Order item in sortList)
            {

                Console.WriteLine("{0,-10} {1:C} {2}", item.Id, item.Price, item.Customer);

            }
            Console.ReadLine();

        }

        private static string apiRequest()
        {

            string json = "";
            //add encoding in order to set correct font on the data
            using (var client = new System.Net.WebClient() { Encoding = System.Text.Encoding.UTF8 })
            {
                json = client.DownloadString("https://api.agify.io?name=isaias");
            }

            return json;
        }

        private static List<Product> lowStock(List<Product> products)
        {
            return (products.Where(x => x.Quantity < 10).ToList());
        }
    }

    class Product
    {
        public string Id { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }

    class Order
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string Customer { get; set; }
    }


}
