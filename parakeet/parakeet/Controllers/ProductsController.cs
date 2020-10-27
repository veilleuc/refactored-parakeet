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
        public IActionResult Index()
        {
            //initialize variable for inputs into arrays
            ProductsViewModel viewModel = new ProductsViewModel();

            //inputing all the type into their specific arrays
            viewModel.designs = _context.Designs.ToArray();
            viewModel.clothingTypes = _context.ClothingTypes.ToArray();
            viewModel.sizes = _context.Sizes.ToArray();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index([Bind("Designs, ClothingTypes, Sizes")] ProductsViewModel viewModel)
        {

            //checking if all buttons have been pressed
            if (ModelState.IsValid)
            {

                //values for the buttons in the view
                var designvalues = viewModel.Designs;
                var clothingTypeValues = viewModel.ClothingTypes;
                var sizeValues = viewModel.Sizes;

                // add an item to the cart
                TempData["ClothingName"] = clothingTypeValues;
                TempData["DesignName"] = designvalues;
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
