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
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> ListProducers()
        {
            var allProducers = await _service.GetAll();
            return View(allProducers);
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
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(ListProducers));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            var actorDetails = await _service.GetId(id);
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(ListProducers));
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            var producerdetails = _service.GetId(id);
            if (producerdetails == null)
            {
                return View("NotFound");
            }
            return View(producerdetails);
        }

        public IActionResult Delete(int id)
        {
            var producerdetails = _service.GetId(id);
            if (producerdetails == null)
            {
                return View("NotFound");
            }
            return View(producerdetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteComfirmed(int id)
        {
            var producerdetails = _service.GetId(id);
            if (producerdetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(ListProducers));
        }
    }
}
