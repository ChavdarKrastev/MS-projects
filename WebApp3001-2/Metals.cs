using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp3001_2
{
    public class Metals
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }



        public Metals(int id, string type, double price, string weight, string image)
        {
            Id = id;
            Type = type;
            Weight = weight;
            Price = price;
            Image = image;
        }

        public Metals(string type, double price, string weight, string image)
        {
            Type = type;
            Weight = weight;
            Price = price;
            Image = image;
        }

    }
}