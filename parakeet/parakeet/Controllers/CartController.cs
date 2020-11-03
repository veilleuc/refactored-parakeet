using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using parakeet.Data;
using parakeet.Helpers;
using parakeet.Models;


namespace parakeet.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
            string clothingName = (string)TempData["ClothingName"];
            int designID = (int)TempData["DesignID"];
            string sizeName = (string)TempData["SizeName"];

            // pull items from database related to the product chosen
            ClothingType type = await _context.ClothingTypes.FirstOrDefaultAsync(c => c.type == clothingName);
            Design design1 = await _context.Designs.FirstOrDefaultAsync(d => d.DesignId == designID);
            Size size1 = await _context.Sizes.FirstOrDefaultAsync(s => s.SizeName == sizeName);

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
        
        [HttpPost]
        public ActionResult Checkout([Bind("Address,City,State,Zipcode")] CheckoutViewModel OrderInfo)
        {
            if (!ModelState.IsValid)
            {
                // if the form was not filled out correctly
                return View(OrderInfo);
            }


            return RedirectToAction("Confirm");
        }

        public async Task<ActionResult> ConfirmAsync()
        {
            // get the cart list from the session
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            foreach(CartItem item in cart)
            {
                // get design from DB so the popularity counter can be incremented
                Design design = _context.Designs.Find(item.design.DesignId);
                // increment the design popularity by 1 then update it in the DB
                design.Popularitycounter += 1;

                // save the change
                _context.SaveChanges();
            }

            


            // check if the buyer is a guest or is a signed in user
            // if they are then the cart must be added to their orderhistory so it can be viewed later
            if (_signInManager.IsSignedIn(User))
            {
                // get the current time so it can be used for OderHistory accessing
                DateTime OrderCreationTime = DateTime.Now;

                // get user info 
                ApplicationUser user = await _userManager.GetUserAsync(User);

                // create new orderhistory
                OrderHistory orderHistory = new OrderHistory
                {
                    ApplicationUser = user,
                    OrderDate = OrderCreationTime
                };
                

                // add orderhistory to DB
                _context.orderHistories.Add(orderHistory);
                _context.SaveChanges();

                // retrieve the newly created orderhistory from DB 
                orderHistory = _context.orderHistories.FirstOrDefault(o => o.OrderDate == OrderCreationTime && o.ApplicationUser == user);

                // loop through each item in the cart 
                foreach (CartItem item in cart)
                {
                    //  create a new order item for the order history
                    OrderItemHistory orderItem = new OrderItemHistory
                    {
                        OrderHistoryId = orderHistory.OrderHistoryId,
                        DesignId = item.design.DesignId,
                        SizeId = item.size.SizeId,
                        ClothingTypeId = item.clothingType.ClothingTypeId
                    };

                    // add the item to DB
                    _context.orderItemHistories.Add(orderItem);
                }

                _context.SaveChanges();

                
            }
            // reset the cart 
            cart = new List<CartItem>();
            // store the new cart back in session
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return View();
        }


    }
}
