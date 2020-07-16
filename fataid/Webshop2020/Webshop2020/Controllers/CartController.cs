using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop2020.Data;
using Webshop2020.Models;

namespace Webshop2020.Controllers
{
    [Authorize] public class CartController : Controller
    {
        private readonly WebshopDbContext context;

        public CartController(WebshopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(Guid ID, int Quantity)
        {
            Cart cart = context.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.Buyer == User.Identity.Name);
            if (cart == null)
            {
                cart = new Cart();
                cart.Buyer = User.Identity.Name;
                context.Carts.Add(cart);
                //context.SaveChanges();
            }
            Product prod = context.Products.FirstOrDefault(x => x.ID == ID);
            //CartItem item = cart.Items.FirstOrDefault(x => x.Product== prod);
            CartItem item = cart.Items.FirstOrDefault(x => x.Product.ID == ID);

            if (item==null)
            {
                //item = new CartItem(prod, Quantity);
                //item = new CartItem(context.Products.FirstOrDefault(x => x.ID == ID), Quantity, cart);
                item = new CartItem() { CartID = cart.ID, ProductID = prod.ID, Count = Quantity, Product = prod };
                //cart.Items.Add(item);
                //cart.Items.Add(new CartItem(context.Products.FirstOrDefault(x => x.ID == ID), Quantity));
                context.Items.Add(item);
            }
            else
            {
                item.Count += Quantity;
            }
            context.SaveChanges();
            int price = cart.Items.Sum(x => x.Count*x.Product.Price);
            int count = cart.Items.Sum(x => x.Count);
            //for (int i=0;i<)
            //{

            //}
            if (TempData.ContainsKey("Count"))
            {
                TempData["Count"] = count;
                TempData["CartPrice"] = price;
            }
            else
            {
                TempData.Add("Count", count);
                TempData.Add("CartPrice", price);
            }
            return RedirectToAction("Product","Home", new { ID });
            //return View("Cart",cart);
        }
    }
}
