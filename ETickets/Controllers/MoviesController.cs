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
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> ListMovies()
        {
            var allMovies = await _service.GetAll();
            return View(allMovies);
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
        public async Task<IActionResult> Create([Bind("Name,Description,Price,ImageUrl,StartDate,EndDate,movieCategory,Cinema,Producer")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.AddAsync(movie);
            return RedirectToAction(nameof(ListMovies));
        }

        public IActionResult Edit(int id)
        {
            var Moviedetails = _service.GetId(id);
            if (Moviedetails == null)
            {
                return View("NotFound");
            }
            return View(Moviedetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name, Description, Price, ImageUrl, StartDate, EndDate, movieCategory, Cinema, Producer")] Movie movie)
        {
            var actorDetails = await _service.GetId(id);
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.UpdateAsync(id, movie);
            return RedirectToAction(nameof(ListMovies));
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            var moviedetails = _service.GetId(id);
            if (moviedetails == null)
            {
                return View("NotFound");
            }
            return View(moviedetails);
        }

        public IActionResult Delete(int id)
        {
            var moviedetails = _service.GetId(id);
            if (moviedetails == null)
            {
                return View("NotFound");
            }
            return View(moviedetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteComfirmed(int id)
        {
            var moviedetails = _service.GetId(id);
            if (moviedetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(ListMovies));
        }
    }
}
