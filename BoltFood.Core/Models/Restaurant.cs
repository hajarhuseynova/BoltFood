using BoltFood.Core.Enums;
using BoltFood.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Restaurant:BaseModel
    {
        private static int _id;
        public RestaurantCategory RstCategory { get; set; }

        public List<Product> Products;

        public double Rating { get; set; }
        public Restaurant(string name,RestaurantCategory rstCategory,double rating)
        {
            _id++;
            Id = _id;
            Name = name;
            Products = new List<Product>();
            RstCategory = rstCategory;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}; Category: {RstCategory}; Rating: {Rating};"; 
        }
    }
}
