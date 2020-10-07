using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parakeet.Data;
using parakeet.Models;

namespace parakeet.Controllers
{
    public class OrderItemHistoriesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public OrderItemHistoriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;

            // for User identity access
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: OrderItemHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.orderItemHistories.Include(o => o.ClothingType).Include(o => o.Design).Include(o => o.OrderHistory).Include(o => o.Size);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderItemHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemHistory = await _context.orderItemHistories
                .Include(o => o.ClothingType)
                .Include(o => o.Design)
                .Include(o => o.OrderHistory)
                .Include(o => o.Size)
                .FirstOrDefaultAsync(m => m.OrderItemHistoryId == id);
            if (orderItemHistory == null)
            {
                return NotFound();
            }

            return View(orderItemHistory);
        }

        // GET: OrderItemHistories/Create
        public IActionResult Create()
        {
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingTypes, "ClothingTypeId", "ClothingTypeId");
            ViewData["DesignId"] = new SelectList(_context.Designs, "DesignId", "DesignId");
            ViewData["OrderHistoryId"] = new SelectList(_context.orderHistories, "OrderHistoryId", "OrderHistoryId");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId");
            return View();
        }

        // POST: OrderItemHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderItemHistoryId,OrderHistoryId,DesignId,ClothingTypeId,SizeId")] OrderItemHistory orderItemHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItemHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingTypes, "ClothingTypeId", "ClothingTypeId", orderItemHistory.ClothingTypeId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "DesignId", "DesignId", orderItemHistory.DesignId);
            ViewData["OrderHistoryId"] = new SelectList(_context.orderHistories, "OrderHistoryId", "OrderHistoryId", orderItemHistory.OrderHistoryId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", orderItemHistory.SizeId);
            return View(orderItemHistory);
        }

        // GET: OrderItemHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemHistory = await _context.orderItemHistories.FindAsync(id);
            if (orderItemHistory == null)
            {
                return NotFound();
            }
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingTypes, "ClothingTypeId", "ClothingTypeId", orderItemHistory.ClothingTypeId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "DesignId", "DesignId", orderItemHistory.DesignId);
            ViewData["OrderHistoryId"] = new SelectList(_context.orderHistories, "OrderHistoryId", "OrderHistoryId", orderItemHistory.OrderHistoryId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", orderItemHistory.SizeId);
            return View(orderItemHistory);
        }

        // POST: OrderItemHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderItemHistoryId,OrderHistoryId,DesignId,ClothingTypeId,SizeId")] OrderItemHistory orderItemHistory)
        {
            if (id != orderItemHistory.OrderItemHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItemHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemHistoryExists(orderItemHistory.OrderItemHistoryId))
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
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingTypes, "ClothingTypeId", "ClothingTypeId", orderItemHistory.ClothingTypeId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "DesignId", "DesignId", orderItemHistory.DesignId);
            ViewData["OrderHistoryId"] = new SelectList(_context.orderHistories, "OrderHistoryId", "OrderHistoryId", orderItemHistory.OrderHistoryId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", orderItemHistory.SizeId);
            return View(orderItemHistory);
        }

        // GET: OrderItemHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemHistory = await _context.orderItemHistories
                .Include(o => o.ClothingType)
                .Include(o => o.Design)
                .Include(o => o.OrderHistory)
                .Include(o => o.Size)
                .FirstOrDefaultAsync(m => m.OrderItemHistoryId == id);
            if (orderItemHistory == null)
            {
                return NotFound();
            }

            return View(orderItemHistory);
        }

        // POST: OrderItemHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItemHistory = await _context.orderItemHistories.FindAsync(id);
            _context.orderItemHistories.Remove(orderItemHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemHistoryExists(int id)
        {
            return _context.orderItemHistories.Any(e => e.OrderItemHistoryId == id);
        }
    }
}
