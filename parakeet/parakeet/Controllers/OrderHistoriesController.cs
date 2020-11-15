using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parakeet.Data;
using parakeet.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace parakeet.Controllers
{
    public class OrderHistoriesController : Controller
    {
        // declare class variables for DB and User Identity
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public OrderHistoriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager )
        {
            // initialize variables

            // for User identity access
            _userManager = userManager;
            _signInManager = signInManager;

            // for DB access
            _context = context;
        }

        // GET: OrderHistories
        [Authorize(Roles = "Admin, Basic")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) 
                return Challenge();

            return View(await _context.orderHistories.Where(c => c.ApplicationUser == currentUser).ToListAsync());
        }

        // GET: OrderHistories/Details/5
        [Authorize(Roles = "Admin, Basic")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var orderHistory = await _context.orderHistories
                .Include(c => c.OrderItemHistory)
                    .ThenInclude(c => c.Size)
                .Include(c => c.OrderItemHistory)
                    .ThenInclude(c => c.ClothingType)
                 .Include(c => c.OrderItemHistory)
                    .ThenInclude(c => c.Design)
                .FirstOrDefaultAsync(m => m.OrderHistoryId == id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return View(orderHistory);
        }

        // GET: OrderHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderHistoryId,OrderDate")] OrderHistory orderHistory)
        {
            
            
            if (ModelState.IsValid)
            {
                //assign user to the order
                orderHistory.ApplicationUser = await _userManager.GetUserAsync(User);
                
                
                _context.Add(orderHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderHistory);
        }

        // GET: OrderHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.orderHistories.FindAsync(id);
            if (orderHistory == null)
            {
                return NotFound();
            }
            return View(orderHistory);
        }

        // POST: OrderHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderHistoryId,OrderDate")] OrderHistory orderHistory)
        {
            if (id != orderHistory.OrderHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderHistoryExists(orderHistory.OrderHistoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderHistory);
        }

        // GET: OrderHistories/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.orderHistories
                .FirstOrDefaultAsync(m => m.OrderHistoryId == id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return View(orderHistory);
        }

        // POST: OrderHistories/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderHistory = await _context.orderHistories.FindAsync(id);
            _context.orderHistories.Remove(orderHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderHistoryExists(int id)
        {
            return _context.orderHistories.Any(e => e.OrderHistoryId == id);
        }
    }
}
