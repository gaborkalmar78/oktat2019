using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Webshop2020.Data;
using Webshop2020.Models;

namespace Webshop2020.Models
{
    public class Helper
    {
        public static Cart FILLTEMPDATA(WebshopDbContext context, string user, ITempDataDictionary TempData, bool filltemp)
        {
            Cart cart = context.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.Buyer == user);
            if (cart == null)
            {
                cart = new Cart();
                cart.Buyer = user;
                context.Carts.Add(cart);
            }
            if(filltemp)
            {
                int price = cart.Items.Sum(x => x.Count * x.Product.Price);
                int count = cart.Items.Sum(x => x.Count);
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
            }

            return cart;
        }
    }
}
