using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using parakeet.Models;
using parakeet.Data;
using Microsoft.AspNetCore.Http;

namespace parakeet.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            //Db access for arrays in the model
            _context = context;
        }
        public IActionResult Index(string button)
        {
            //initialize variable for inputs into arrays
            ProductsViewModel viewModel = new ProductsViewModel();

            //inputing clothing and sizes into their specific arrays
            viewModel.clothingTypes = _context.ClothingTypes.ToArray();
            viewModel.sizes = _context.Sizes.ToArray();

            if (!String.IsNullOrEmpty(button))
            {
                if (button == "Nature")
                {
                    viewModel.designs = _context.Designs.Where(d => d.Approved == true && d.NatureTag == true).ToArray();
                    return View(viewModel);
                }
                else if (button == "Funny")
                {
                    viewModel.designs = _context.Designs.Where(d => d.Approved == true && d.FunnyTag == true).ToArray();
                    return View(viewModel);
                }
                else if (button == "Abstract")
                {
                    viewModel.designs = _context.Designs.Where(d => d.Approved == true && d.AbstractTag == true).ToArray();
                    return View(viewModel);
                }
                else if (button == "Game")
                {
                    viewModel.designs = _context.Designs.Where(d => d.Approved == true && d.GameTag == true).ToArray();
                    return View(viewModel);
                }
                else if (button == "Music")
                {
                    viewModel.designs = _context.Designs.Where(d => d.Approved == true && d.MusicTag == true).ToArray();
                    return View(viewModel);
                }
                else if (button == "Movie")
                {
                    viewModel.designs = _context.Designs.Where(d => d.Approved == true && d.MovieTag == true).ToArray();
                    return View(viewModel);
                }
                else if (button == "Cool")
                {
                    viewModel.designs = _context.Designs.Where(d => d.Approved == true && d.CoolTag == true).ToArray();
                    return View(viewModel);
                }
            }
            else
            {
                // pull designs with only approved check
                viewModel.designs = _context.Designs.Where(d => d.Approved == true).ToArray();
            }
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index([Bind("Designs, ClothingTypes, Sizes")] ProductsViewModel viewModel)
        {
            //checking if all buttons have been pressed
            if (ModelState.IsValid && viewModel.Designs > 0 )
            {
                //values for the buttons in the view
                var designvalues = viewModel.Designs;
                var clothingTypeValues = viewModel.ClothingTypes;
                var sizeValues = viewModel.Sizes;

                // add an item to the cart
                TempData["ClothingName"] = clothingTypeValues;
                TempData["DesignID"] = designvalues;
                TempData["SizeName"] = sizeValues;
                return RedirectToAction("Add", "Cart");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
