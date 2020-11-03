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
    public class AdminDashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AdminDashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            // for User identity access
            _userManager = userManager;
            _signInManager = signInManager;

            // for DB access
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        // GET: AdminDashboard
        public async Task<IActionResult> Index()
        {
            return View(await _context.Designs.Where(c => !c.AdminViewed.Equals(true)).ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        // GET: AdminDashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var design = await _context.Designs
                .FirstOrDefaultAsync(m => m.DesignId == id);
            if (design == null)
            {
                return NotFound();
            }

            return View(design);
        }
        [Authorize(Roles = "Admin")]
        // GET: AdminDashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var design = await _context.Designs.FindAsync(id);
            if (design == null)
            {
                return NotFound();
            }
            return View(design);
        }
        [Authorize(Roles = "Admin")]
        // POST: AdminDashboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [RequestSizeLimit(1048576000)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesignId,DesignArray,DesignName,Popularitycounter,Approved,AdminViewed,NatureTag,FunnyTag,AbstractTag,GameTag,MusicTag,MovieTag,CoolTag,UserId")] Design design)
        {
            if (id != design.DesignId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(design);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignExists(design.DesignId))
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
            return View(design);
        }
        [Authorize(Roles = "Admin")]
        // GET: AdminDashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var design = await _context.Designs
                .FirstOrDefaultAsync(m => m.DesignId == id);
            if (design == null)
            {
                return NotFound();
            }

            return View(design);
        }
        [Authorize(Roles = "Admin")]
        // POST: AdminDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var design = await _context.Designs.FindAsync(id);
            _context.Designs.Remove(design);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignExists(int id)
        {
            return _context.Designs.Any(e => e.DesignId == id);
        }
    }
}
