﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetShopProject.Models
{
    public class Product
    {
        public int id { get; set; }

        [DisplayName("Product Name")]
        public string prodName { get; set; }

        public float price { get; set; }

        [DisplayName("Descriptions")]
        public string description { get; set; }

        public int quantity { get; set; }

        //NEED TO ASK:
        // public int pincode { get; set; }

        [NotMapped]
        public IFormFile images { get; set; }
        [DisplayName("Images")]
        public string imgpath { get; set; }


        [ForeignKey("cat")]
        [DisplayName("Category")]
        public int catID { get; set; }
        public Category cat { get; set; }


        [ForeignKey("city")]
        public int cityID { get; set; }
        public City city { get; set; }


    }

    public class City
    {
        public int id { get; set; }
        public string city { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }

    }

    public class Cart
    {
        [DisplayName("Order ID")]
        public int id { get; set; }

        public float totalPrice { get; set; }
        public int quantity { get; set; }

        public DateTime timeStamp { get; set; }

        public float Discount { get; set; }

        public float finalAmount { get; set; }


        [ForeignKey("prod")]
        public int prodID { get; set; }
        public Product prod { get; set; }

        [ForeignKey("catID")]
        public int catID { get; set; }
        public Category cat { get; set; }

    }

    public class Inventory
    {
        [DisplayName("Inventory ID")]
        public int id { get; set; }

        public int quantityAvail { get; set; }

        public int totalQuantity { get; set; }

        public int totalSold { get; set; }

        [ForeignKey("prod")]
        public int prodID { get; set; }
        public Product prod { get; set; }

        [ForeignKey("catID")]
        public int catID { get; set; }
        public Category cat { get; set; }
    }


    public class SweetContext : DbContext
    {
        public SweetContext(DbContextOptions<SweetContext> options) : base(options)
        {

        }
        public DbSet<Category> category { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Inventory> inventory { get; set; }
        public DbSet<Cart> cart { get; set; }

        public DbSet<City> cities { get; set; }
    }

}
