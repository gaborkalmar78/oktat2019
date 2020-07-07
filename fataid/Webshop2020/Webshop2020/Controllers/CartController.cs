using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop2020.Data;
using Webshop2020.Models;

namespace Webshop2020.Controllers
{
    public class CartController : Controller
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
            Cart cart = context.Carts.Include(x => x.Items).FirstOrDefault(x => x.Buyer == User.Identity.Name);
            if (cart == null)
            {
                cart = new Cart();
                cart.Buyer = User.Identity.Name;
                context.Carts.Add(cart);
                context.SaveChanges();
            }
            //Product prod = context.Products.FirstOrDefault(x => x.ID == ID);
            //CartItem item = cart.Items.FirstOrDefault(x => x.Product== prod);
            CartItem item = cart.Items.FirstOrDefault(x => x.Product.ID == ID);
            if (item==null)
            {
                //item = new CartItem(prod, Quantity);
                item = new CartItem(context.Products.FirstOrDefault(x => x.ID == ID), Quantity, cart);
                cart.Items.Add(item);
                //cart.Items.Add(new CartItem(context.Products.FirstOrDefault(x => x.ID == ID), Quantity));
            }
            else
            {
                item.Count += Quantity;
            }
            context.SaveChanges();
            return View(cart);
        }
    }
}
