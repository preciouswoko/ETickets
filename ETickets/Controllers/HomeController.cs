using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListProducers()
        {
            var allProducers = await _context.Producers.ToListAsync();
            return View(allProducers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producer producer)
        {

            if (ModelState.IsValid)
            {
                _context.Producers.Add(producer);
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(ListProducers));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(int? id, Producer producer)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var output = _context.Producers.FirstOrDefault(m => m.Id == id);
                return View(output);
            }

            return RedirectToAction(nameof(ListProducers));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Producer producer)
        {
            if (id == null)
            {
                return NotFound();
            }

            var output = _context.Producers.Find(id);
            _context.Producers.Update(output);
            _context.SaveChanges();
            return RedirectToAction(nameof(ListProducers));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var output = _context.Producers.Find(id);
            _context.Producers.Remove(output);
            _context.SaveChanges();
            return RedirectToAction(nameof(ListProducers));
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
