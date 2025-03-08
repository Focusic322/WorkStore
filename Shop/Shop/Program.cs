using System.Security.Cryptography.X509Certificates;

namespace StoreApp
{

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Store
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<string> SearchProducts(string searchTerm)
        {
            return products
                .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .Select(p => p.Name)
                .ToList();
        }

        public void DisplayAllProducts()
        {
            Console.WriteLine("All products in the store:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - ${product.Price}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();

            store.AddProduct(new Product("Course from snake oil salesman", 1999.99m));
            store.AddProduct(new Product("Best AI from python developers", 11999.99m));
            store.AddProduct(new Product("Latte on coconut", 99.99m));
            store.AddProduct(new Product("Macbook for real snake oil salesman", 999.99m));


            store.DisplayAllProducts();

            Console.WriteLine("Enter product: ");
            string searchTerm = Console.ReadLine();
            var results = store.SearchProducts(searchTerm);

            if (results.Any())
            {
                Console.WriteLine("Found products:");
                foreach (var productName in results)
                {
                    Console.WriteLine(productName);
                }
            }
            else
            {
                Console.WriteLine("No products found");
            }
        }
    }
}
