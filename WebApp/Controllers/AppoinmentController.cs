using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AppoinmentController : Controller
    {
        private IAppoinmentViewModelService _serviceRepo;
        public AppoinmentController(IAppoinmentViewModelService repo)
        {
            _serviceRepo = repo;       
        }

        public async Task<IActionResult> Index()
        {
            return View(await _serviceRepo.GetListOfAppoinments());
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> View(int id)
        {
            return View(await _serviceRepo.ViewAppoinment(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppoinmentViewModel viewModel)
        {
            _serviceRepo.CreateAppoinment(viewModel);
            return View(new AppoinmentViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScheduleViewModel viewModel)
        {
            _serviceRepo.UpdateAppoinment(viewModel);
            return RedirectToAction("Index");
        }
    }
}
