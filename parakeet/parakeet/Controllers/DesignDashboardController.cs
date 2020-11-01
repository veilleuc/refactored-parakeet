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
    public class DesignDashboardController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public DesignDashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            // for User identity access
            _userManager = userManager;
            _signInManager = signInManager;

            // for DB access
            _context = context;
        }
        [Authorize(Roles = "Basic")]
        // GET: DesignDashboard
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge();

            return View(await _context.Designs.Where(c => c.ApplicationUser == currentUser).ToListAsync());
        }
       
        [Authorize(Roles = "Basic")]
        // GET: DesignDashboard/Delete/5
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

        [Authorize(Roles = "Basic")]
        // POST: DesignDashboard/Delete/5
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
