using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using parakeet.Models;
using Microsoft.EntityFrameworkCore;
using parakeet.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace parakeet.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(ProductsViewModel viewModel)
        {
            viewModel.designs = _context.Designs.ToArray();
            viewModel.clothingTypes = _context.ClothingTypes.ToArray();
            viewModel.sizes = _context.Sizes.ToArray();

            return View(viewModel);
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
