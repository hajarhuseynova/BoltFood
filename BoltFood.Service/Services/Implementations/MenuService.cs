using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoltFood.Service.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IRestaurantService _restaurantService = new RestaurantService();
        private readonly IProductService _productService = new ProductService();
        public async Task ShowMenuAsync()
        {
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                         BOLT FOOD                           ");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;
            bool status1 = true;
            bool status2 = true;
            while (status1)
            {
                ShowMenu();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter your choice: ");
                string step1 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                switch (step1)
                {
                    case "1":
                        while (status2)
                        {
                            ShowRes();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Enter your choice: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string step2 = Console.ReadLine();
                            switch (step2)
                            {
                                case "1":
                                    await CreateRestaurant();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "2":
                                    await ShowAllRestaurants();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "3":
                                    await GetRestaurantById();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "4":
                                    await SortRestaurantByRating();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "5":
                                    await UpdateRestaurant();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "6":
                                    await RemoveRestaurant();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "7":
                                    Console.Clear();
                                    break;
                                case "0":
                                    status2 = false;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Enter The Right Step!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }

                        }
                        status2 = true;
                        break;
                    case "2":
                        while (status2)
                        {
                            ShowPro();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Enter your choice: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string step3 = Console.ReadLine();
                            switch (step3)
                            {
                                case "1":
                                    await CreateProduct();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "2":
                                    await ShowAllProducts();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "3":
                                    await GetProductById();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "4":
                                    await UpdateProduct();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "5":
                                    await RemoveProduct();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "6":
                                    Console.Clear();
                                    break;
                                case "0":
                                    status2 = false;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Enter The Right Step!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }
                        }
                        status2 = true;
                        break;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Left");
                        Console.ForegroundColor = ConsoleColor.White;
                        status1 = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter The Right Step!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
        private void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Menu:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1.Restaurant");
            Console.WriteLine("2.Product");
            Console.WriteLine("0.Left");
        }
        private void ShowRes()
        {
            Console.WriteLine("1.Create Restaurant");
            Console.WriteLine("2.Show All Restaurants");
            Console.WriteLine("3.Get Restaurant By Id");
            Console.WriteLine("4.Sort Restaurant By Rating");
            Console.WriteLine("5.Update Restaurant");
            Console.WriteLine("6.Remove Restaurant");
            Console.WriteLine("7.Clear");
            Console.WriteLine("0.Back to Menu");
        }
        private void ShowPro()
        {
            Console.WriteLine("1.Create Product");
            Console.WriteLine("2.Show All Products");
            Console.WriteLine("3.Get Product By Id");
            Console.WriteLine("4.Update Product");
            Console.WriteLine("5.Remove Product");
            Console.WriteLine("6.Clear");
            Console.WriteLine("0.Back to Menu");
        }
        private bool CheckString(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong!Please enter Name correctly!!!");
                return false;
            }
            return true;
        }
        private bool CheckPrice(double price)
        {
            if (price <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong!Please Enter Price correctly!!!");
                return false;
            }
            return true;
        }
        private bool CheckRating(double rating)
        {
            if (rating <= 0 || rating > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong!Please Enter Rating correctly!!!");
                return false;
            }
            return true;
        }
        private async Task<bool> CheckRestaurant()
        {
            List<Restaurant> restaurants = await _restaurantService.GetAllAsync();
            if (restaurants.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("We don't have any Restaurants!");
                return false;
            }
            return true;
        }
    
        private async Task<bool> CheckProduct()
        {
            List<Product> products = await _productService.GetAllAsync();
            if (products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("We don't have any Products!");
                return false;
            }
            return true;

        }
        private async Task CreateRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter Restaurant's Name");
                name = Console.ReadLine();

            }
            while (!CheckString(name));

            int RstCategory;
            while (true)
            {
                    Console.WriteLine("Choose Restaurant's Category");
                    var Enums = Enum.GetValues(typeof(RestaurantCategory));

                    foreach (var category in Enums)
                    {
                        Console.WriteLine((int)category + "." + category);
                    }
                    int.TryParse(Console.ReadLine(), out RstCategory);
                try
                {
                    Enums.GetValue(RstCategory - 1);
                    break;
                }

                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Something wrong!Try Again!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            double rating;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter Restaurant's Rating:");
                double.TryParse(Console.ReadLine(), out rating);

            }
            while (!CheckRating(rating));

            string message = await _restaurantService.CreateAsync(name, rating, (RestaurantCategory)RstCategory);
            Console.WriteLine(message);
        }
        private async Task ShowAllRestaurants()
        {
            List<Restaurant> restaurants = await _restaurantService.GetAllAsync();

            if (!await CheckRestaurant())
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var items in restaurants)
            {
                Console.WriteLine(items);
            }
        }
        private async Task GetRestaurantById()
        {
            if (!await CheckRestaurant())
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter Restaurant's Id:");
            int.TryParse(Console.ReadLine(), out int id);

            Restaurant Restaurant = await _restaurantService.GetAsync(id);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Restaurant);
        }
        private async Task SortRestaurantByRating()
        {
            List<Restaurant> restaurants = await _restaurantService.SortRestaurantByRating();
            if (!await CheckRestaurant())
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var items in restaurants)
            {
                Console.WriteLine(items);
            }
        }
        private async Task UpdateRestaurant()
        {
            if (!await CheckRestaurant())
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Restaurant's Id:");
            int.TryParse(Console.ReadLine(), out int id);

            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter Restaurant's Name");
                name = Console.ReadLine();
            }
            while (!CheckString(name));

            string message = await _restaurantService.UpdateAsync(id, name);
            Console.WriteLine(message);
        }
        private async Task RemoveRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (!await CheckRestaurant())
            {
                return;
            }

            Console.WriteLine("Enter Restaurant's Id:");
            int.TryParse(Console.ReadLine(), out int id);

            string message = await _restaurantService.RemoveAsync(id);
            Console.WriteLine(message);
        }
        private async Task CreateProduct()
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (!await CheckRestaurant())
            {
                return;
            }

            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter Product's Name");
                name = Console.ReadLine();

            }
            while (!CheckString(name));

            double price;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter Product's Price:");
                double.TryParse(Console.ReadLine(),out price);

            }
            while (!CheckPrice(price));

            Console.WriteLine("Enter Restaurant's Id:");
            int.TryParse(Console.ReadLine(), out int id);

            int PrdctCategory;
            while (true)
            {
                Console.WriteLine("Choose Restaurant's Category");
                var Enums = Enum.GetValues(typeof(ProductCategory));

                foreach (var category in Enums)
                {
                    Console.WriteLine((int)category + "." + category);

                }
                int.TryParse(Console.ReadLine(), out PrdctCategory);

                try
                {
                    Enums.GetValue(PrdctCategory - 1);
                    break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Enter Right Product Category");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            string message = await _productService.CreateAsync(name, price, id, (ProductCategory)PrdctCategory);
            Console.WriteLine(message);

        }
        private async Task ShowAllProducts()
        {
            List<Product> products = await _productService.GetAllAsync();

            if (!await CheckProduct())
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (var items in products)
            {
                Console.WriteLine(items);
            }
        }
        private async Task GetProductById()
        {
            if (!await CheckProduct())
            {
                return;
            }

            Console.WriteLine("Enter Product's id:");
            int.TryParse(Console.ReadLine(), out int id);

            Product Product = await _productService.GetAsync(id);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Product);
        }
        private async Task UpdateProduct()
        {
            if (!await CheckProduct())
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter Product's Id:");
            int.TryParse(Console.ReadLine(), out int id);

            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter Product's Name");
                name = Console.ReadLine();

            }
            while (!CheckString(name));

            double price;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter Product's Price:");
                double.TryParse(Console.ReadLine(), out price);

            }
            while (!CheckPrice(price));

            string message = await _productService.UpdateAsync(id, name, price);
            Console.WriteLine(message);
        }
        private async Task RemoveProduct()
        {
            if (!await CheckProduct())
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;
           
            Console.WriteLine("Enter Product's Id:");
            int.TryParse(Console.ReadLine(), out int id);

            string message = await _productService.RemoveAsync(id);
            Console.WriteLine(message);
        }
    }
}
