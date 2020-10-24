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
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CartController
        public ActionResult Index()
        {
            // add cartitem list to viewbag then go to index view page
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            // if the cart has not been created or the cart is currently empty
            if (cart == null || cart.Count == 0)
            {
                ViewData["Empty"] = true;
                return View();
            }

            ViewData["Empty"] = false;
            ViewBag.cart = cart;
            // add the cost of all items so that the  final price can be displayed
            ViewBag.total = cart.Sum(item => item.clothingType.price);
            return View();
        }

        // GET: CartController/Add
        public async Task<ActionResult> AddAsync()
        {
            string clothingID = (string)TempData["ClothingName"];
            string designID = (string)TempData["DesignName"];
            string sizeID = (string)TempData["SizeName"];

            // pull items from database related to the product chosen
            ClothingType type = await _context.ClothingTypes.FirstOrDefaultAsync(c => c.type == clothingID);
            Design design1 = await _context.Designs.FirstOrDefaultAsync(d => d.DesignName == designID);
            Size size1 = await _context.Sizes.FirstOrDefaultAsync(s => s.SizeName == sizeID);

            // create a new cartitem obj
            CartItem item = new CartItem
            {
                clothingType = type,
                design = design1,
                size = size1

            };
            // if session list has not been created then create a new one and add item
            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();

                cart.Add(item);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            // session list has been created so just add item to list
            else
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                cart.Add(item);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            // after item has been added to session list, return to the cart page for viewing
            return RedirectToAction("Index");
        }

        // GET: CartController/Remove
        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int index = (int)id;

            // get the cart from the session
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            
            // remove the item at the cart index
            cart.RemoveAt(index);

            // add the updated cart back to the session
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        // GET: should visit when user clicks checkout from cart index page
        public ActionResult Checkout()
        {
            
            return View();
        }


    }
}
