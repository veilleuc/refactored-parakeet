using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parakeet.Data;
using parakeet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace parakeet.Controllers
{
 
    public class OrderHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderHistoriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: OrderHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.orderHistories.Include(o => o.ClothingType).Include(o => o.Design);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {   
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.orderHistories
                .Include(o => o.ClothingType)
                .Include(o => o.Design)
                .FirstOrDefaultAsync(m => m.OrderHistoryId == id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return View(orderHistory);
        }

        [Authorize(Roles = "Admin")]
        // GET: OrderHistories/Create
        public IActionResult Create()
        {
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingTypes, "ClothingTypeId", "type");
            ViewData["DesignId"] = new SelectList(_context.Designs, "DesignId", "DesignName");
            return View();
        }

        // POST: OrderHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderHistoryId,OrderDate,ClothingTypeId,DesignId")] OrderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingTypes, "ClothingTypeId", "ClothingTypeId", orderHistory.ClothingTypeId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "DesignId", "DesignId", orderHistory.DesignId);
            return View(orderHistory);
        }

        [Authorize(Roles = "Admin")]
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
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingTypes, "ClothingTypeId", "ClothingTypeId", orderHistory.ClothingTypeId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "DesignId", "DesignId", orderHistory.DesignId);
            return View(orderHistory);
        }

        // POST: OrderHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderHistoryId,OrderDate,ClothingTypeId,DesignId")] OrderHistory orderHistory)
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
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingTypes, "ClothingTypeId", "ClothingTypeId", orderHistory.ClothingTypeId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "DesignId", "DesignId", orderHistory.DesignId);
            return View(orderHistory);
        }
        
        [Authorize(Roles = "Admin")]
        // GET: OrderHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.orderHistories
                .Include(o => o.ClothingType)
                .Include(o => o.Design)
                .FirstOrDefaultAsync(m => m.OrderHistoryId == id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return View(orderHistory);
        }
        
        [Authorize(Roles = "Admin")]
        // POST: OrderHistories/Delete/5
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
