using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parakeet.Data;
using parakeet.Models;

namespace parakeet.Controllers
{
    public class DesignsController : Controller { 

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
    
        private readonly ApplicationDbContext _context;

        public DesignsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            // initialize variables

            // for User identity access
            _userManager = userManager;
            _signInManager = signInManager;

            // for DB access
            _context = context;
        }

        // GET: Designs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Designs.ToListAsync());
        }

        // GET: Designs/Details/5
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

        [Authorize(Roles = "Admin, Basic")]
        // GET: Designs/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Designs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesignId,DesignArray,DesignName,Popularitycounter,Approved,AdminViewed,NatureTag,FunnyTag,AbstractTag,GameTag,MusicTag,MovieTag,CoolTag,UserId")] DesignViewModel designview)
        {
            // convert Design view to a Designs obj
            if (ModelState.IsValid && ((Path.GetExtension(designview.DesignArray.FileName).ToLower() == ".jpg") ||
                (Path.GetExtension(designview.DesignArray.FileName).ToLower() == ".jpeg") ||
                (Path.GetExtension(designview.DesignArray.FileName).ToLower() == ".png")))
            {
                Design design = new Design
                {
                    DesignName = designview.DesignName,
                    Popularitycounter = 0,
                    Approved = false,
                    AdminViewed = false,
                    AbstractTag = designview.AbstractTag,
                    CoolTag = designview.CoolTag,
                    FunnyTag = designview.FunnyTag,
                    GameTag = designview.GameTag,
                    MovieTag = designview.MovieTag,
                    MusicTag = designview.MusicTag,
                    NatureTag = designview.NatureTag,

                };

                // convert image to a Byte Array
                IFormFile file = designview.DesignArray;
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    design.DesignArray = dataStream.ToArray();
                }

                // assign user to the design
                design.ApplicationUser = await _userManager.GetUserAsync(User);

                // add design to table
                _context.Add(design);
                await _context.SaveChangesAsync();

                // redirect back to designs index page
                return RedirectToAction("Index", "DesignDashboard");
            }
            else if (ModelState.IsValid)
            {
                // the model is valid but the user tried to submit something other than image
                ViewData["imageError"] = "Image must either: .jpg, .jpeg, .png";
                return View(designview);
            }
            else
            {
                // model was not valid
                ViewData["imageError"] = "";
                return View(designview);
            }
        }

        // GET: Designs/Edit/5
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

        // POST: Designs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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

        // GET: Designs/Delete/5
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

        // POST: Designs/Delete/5
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
