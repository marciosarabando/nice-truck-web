using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceTruck.Application.Interfaces;
using NiceTruck.Application.ViewModels;
using NiceTruck.Repository.Data;

namespace NiceTruck.Web.Controllers
{
    public class TruckController : Controller
    {
        private readonly ITruckBll _truckBll;

        public TruckController(ITruckBll truckBll)
        {
            _truckBll = truckBll;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _truckBll.GetAllTrucksEnablesAsync(HttpContext.RequestAborted));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            return View(await _truckBll.GetDetailsTruckEnableByIdAsync(id, HttpContext.RequestAborted));
        }

        public async Task<IActionResult> Create()
        {
            var fabricationYear = new List<int>();
            var modelYear = new List<int>();

            fabricationYear.Add(int.Parse(DateTime.Now.ToString("yyyy")));

            modelYear.Add(int.Parse(DateTime.Now.ToString("yyyy")));
            modelYear.Add(int.Parse(DateTime.Now.ToString("yyyy")) + 1);

            ViewData["FabricationYear"] = new SelectList(fabricationYear);
            ViewData["ModelYear"] = new SelectList(modelYear);

            var truckViewModel = await _truckBll.PopulateTruckModels(new Application.ViewModels.TruckViewModel(), HttpContext.RequestAborted);

            return View(truckViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TruckViewModel truck)
        {
            if (ModelState.IsValid)
            {
                await _truckBll.CreateTruckAsync(truck, HttpContext.RequestAborted);

                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTruckModel"] = new SelectList(_context.TrucksModels, "Id", "Id", truck.TruckModel.Id);

            return View(truck);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = await _truckBll.GetTruckEnableByIdAsync(id, HttpContext.RequestAborted);

            if (truck == null)
                return NotFound();

            truck = await _truckBll.PopulateTruckModels(truck, HttpContext.RequestAborted);

            var fabricationYear = new List<int>();
            var modelYear = new List<int>();

            fabricationYear.Add(int.Parse(DateTime.Now.ToString("yyyy")));

            modelYear.Add(int.Parse(DateTime.Now.ToString("yyyy")));
            modelYear.Add(int.Parse(DateTime.Now.ToString("yyyy")) + 1);

            ViewData["FabricationYear"] = new SelectList(fabricationYear);
            ViewData["ModelYear"] = new SelectList(modelYear);

            return View(truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TruckViewModel truck)
        {
            if (id != truck.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _truckBll.UpdateTruckAsync(id, truck, HttpContext.RequestAborted);

                return RedirectToAction(nameof(Index));
            }

            return View(truck);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = await _truckBll.GetDetailsTruckEnableByIdAsync(id, HttpContext.RequestAborted);

            if (truck == null)
                return NotFound();

            return View(truck);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _truckBll.DeleteTruckAsync(id, HttpContext.RequestAborted);

            return RedirectToAction(nameof(Index));
        }
    }
}
