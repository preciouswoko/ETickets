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
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ListActors()
        {
            var allActors = await _service.GetAll();
            return View(allActors);
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
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(ListActors));
        }

        public IActionResult Edit(int id)
        {
            var actordetails = _service.GetId(id);
            if (actordetails == null)
            {
                return View("NotFound");
            }
            return View(actordetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            var actorDetails = await _service.GetId(id);
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(ListActors));
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            var actordetails = _service.GetId(id);
            if (actordetails == null)
            {
                return View("NotFound");
            }
            return View(actordetails);
        }

        public IActionResult Delete(int id)
        {
            var actordetails = _service.GetId(id);
            if (actordetails == null)
            {
                return View("NotFound");
            }
            return View(actordetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteComfirmed(int id)
        {
            var actordetails = _service.GetId(id);
            if (actordetails == null)
            {
                return View("NotFound");
            }
          
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(ListActors));
        }
    }
}
