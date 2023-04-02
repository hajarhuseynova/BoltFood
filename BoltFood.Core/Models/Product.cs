using BoltFood.Core.Enums;
using BoltFood.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Product:BaseModel
    {
        private static int _id;
        public double Price { get; set; }
       public Restaurant Restaurant { get; set; }

        public ProductCategory PrdctCategory { get; set; }

        public Product(string name,double price,Restaurant restaurant, ProductCategory prdctCategory)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            Restaurant = restaurant;
            PrdctCategory = prdctCategory;
        }
        public override string ToString()
        {
            return $" Product's Id: {Id}; Product's Category: {PrdctCategory}; Product's Name: {Name}; Restaurant's Name: {Restaurant.Name}; Product's Price: {Price}$;";
        }
    }
}
