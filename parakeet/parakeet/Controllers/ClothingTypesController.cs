using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parakeet.Data;
using parakeet.Models;

namespace parakeet.Controllers
{
    public class ClothingTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClothingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // THIS Authorize() CAN BE USED TO MAKE SURE THAT A LOGGED IN USER HAS RIGHT ROLE TO ACCESS THE PAGE
        // THIS IS EXAMPLE WHERE ONLY A USER WITH Admin ROLE CAN ACCESS ANY OF THE CLOTHING TYPE PAGES
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.ClothingTypes.ToListAsync());
        }

        // GET: ClothingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothingType = await _context.ClothingTypes
                .FirstOrDefaultAsync(m => m.ClothingTypeId == id);
            if (clothingType == null)
            {
                return NotFound();
            }

            return View(clothingType);
        }

        // GET: ClothingTypes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClothingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClothingTypeId,type,price")] ClothingType clothingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clothingType);
        }

        [Authorize(Roles = "Admin")]
        // GET: ClothingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothingType = await _context.ClothingTypes.FindAsync(id);
            if (clothingType == null)
            {
                return NotFound();
            }
            return View(clothingType);
        }

        // POST: ClothingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClothingTypeId,type,price")] ClothingType clothingType)
        {
            if (id != clothingType.ClothingTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingTypeExists(clothingType.ClothingTypeId))
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
            return View(clothingType);
        }

        [Authorize(Roles = "Admin")]
        // GET: ClothingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothingType = await _context.ClothingTypes
                .FirstOrDefaultAsync(m => m.ClothingTypeId == id);
            if (clothingType == null)
            {
                return NotFound();
            }

            return View(clothingType);
        }

        // POST: ClothingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothingType = await _context.ClothingTypes.FindAsync(id);
            _context.ClothingTypes.Remove(clothingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothingTypeExists(int id)
        {
            return _context.ClothingTypes.Any(e => e.ClothingTypeId == id);
        }
    }
}
