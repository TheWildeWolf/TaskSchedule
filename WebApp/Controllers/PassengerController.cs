using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PassengerController : Controller
    {
        private IPassengerViewModelService _serviceRepo;

        public PassengerController(IPassengerViewModelService repo)
        {
            _serviceRepo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _serviceRepo.GetListOfPassengers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PassengerViewModel viewModel)
        {
            _serviceRepo.CreatePassenger(viewModel);
            ModelState.Clear();
            return View(new PassengerViewModel());
        }


        public async Task<ActionResult> View(int id)
        {
            return View(await _serviceRepo.ViewPassenger(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id,int appoinmentId)
        {
            _serviceRepo.Update(id, appoinmentId);
            return RedirectToAction("Index");
        }
    }
}
