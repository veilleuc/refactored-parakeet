using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parakeet.Data;
using parakeet.Helpers;
using parakeet.Models;


namespace parakeet.Controllers
{
    public class CartController : Controller
    {
        // GET: CartController
        public ActionResult Index()
        {
            // add cartitem list to viewbag then go to index view page
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            return View();
        }

        // GET: CartController/Add
        public ActionResult Add(CartItem cartItem)
        {
            // if session list has not been created then create a new one and add item
            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(cartItem);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            // session list has been created so just add item to list
            else
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                cart.Add(cartItem);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index");
        }

        // GET: CartController/Remove
        public ActionResult Remove()
        {
            return View();
        }


    }
}
