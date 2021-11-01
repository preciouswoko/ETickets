using ETickets.Data;
using ETickets.Models;
using ETickets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> ListCinemas()
        {
            var allCinemas = await _service.GetAll();
            return View(allCinemas);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(ListCinemas));
        }

        public IActionResult Edit(int id)
        {
            var cinemadetails = _service.GetId(id);
            if (cinemadetails == null)
            {
                return View("NotFound");
            }
            return View(cinemadetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Logo,Description")] Cinema cinema)
        {
            var cinemaDetails = await _service.GetId(id);
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(ListCinemas));
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            var cinemadetails = _service.GetId(id);
            if (cinemadetails == null)
            {
                return View("NotFound");
            }
            return View(cinemadetails);
        }

        public IActionResult Delete(int id)
        {
            var cinemadetails = _service.GetId(id);
            if (cinemadetails == null)
            {
                return View("NotFound");
            }
            return View(cinemadetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteComfirmed(int id)
        {
            var cinemadetails = _service.GetId(id);
            if (cinemadetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(ListCinemas));
        }
    }
}
