using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Core.Repositories.RestaurantRepository;
using BoltFood.Data.Repositories.RestaurantRepository;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository = new RestaurantRepository();
        public async Task<string> CreateAsync(string name,double rating,RestaurantCategory RstCategory)
        {
            Restaurant Restaurant = new Restaurant(name,RstCategory,rating);
            await _restaurantRepository.AddAsync(Restaurant);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return "Succesfully CREATE";
        }
        public async Task<List<Restaurant>> GetAllAsync()
        {
           List<Restaurant> list= await _restaurantRepository.GetAllAsync();
            return list;    
        }
        public async Task<Restaurant> GetAsync(int id)
        {
           Restaurant Restaurant= await _restaurantRepository.GetAsync(x=>x.Id== id);
            if (Restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Wrong!Restaurant is not found!");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
            return Restaurant;  
        }
        public async Task<string> RemoveAsync(int id)
        {
            Restaurant Restaurant = await _restaurantRepository.GetAsync(x => x.Id == id);
         
            await _restaurantRepository.RemoveAsync(Restaurant);

            if(Restaurant == null)
            {

                Console.ForegroundColor = ConsoleColor.DarkRed;
                return "Wrong Id!";
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return "Succesfully REMOVE";
        }
        public async Task<List<Restaurant>> SortRestaurantByRating()
        {
            List<Restaurant> list = await _restaurantRepository.GetAllAsync();
            list.Sort((a, b) => b.Rating.CompareTo(a.Rating));  
            return list;
        }
        public async Task<string> UpdateAsync(int id,string name)
        {
            Restaurant Restaurant = await _restaurantRepository.GetAsync(x => x.Id == id);

            if(Restaurant == null)
            {
                Console.ForegroundColor= ConsoleColor.DarkRed;
                return "Restaurant is not found";
            }

            Restaurant.Name = name;

            await _restaurantRepository.UpdateAsync(Restaurant);    

            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully UPDATE";
           

        }
    }
}
