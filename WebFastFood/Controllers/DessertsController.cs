using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using Models;
using Microsoft.Extensions.Logging;
using WebFastFood.Repository.IRepositories;

namespace WebFastFood.Controllers
{
    public class DessertsController : Controller
    {
        private readonly ILogger<DessertsController> _logger;
        private IDessertRepository _repository;
        public DessertsController(ILogger<DessertsController> logger, IDessertRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: Desserts
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetDessertsAsync());
        }

        // GET: Desserts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _repository.GetDessertAsync((int)id);
            if (dessert == null)
            {
                return NotFound();
            }

            return View(dessert);
        }

        // GET: Desserts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desserts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Millimeter,IsFrozen,Id,Name,Price,Description")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(dessert);
                return RedirectToAction(nameof(Index));
            }
            return View(dessert);
        }

        // GET: Desserts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _repository.GetDessertAsync((int)id);
            if (dessert == null)
            {
                return NotFound();
            }
            return View(dessert);
        }

        // POST: Desserts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Millimeter,IsFrozen,Id,Name,Price,Description")] Dessert dessert)
        {
            if (id != dessert.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(dessert);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DessertExists(dessert.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dessert);
        }

        // GET: Desserts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var dessert = await _repository.GetDessertAsync((int)id);
            if (dessert == null) return NotFound();
            return View(dessert);
        }

        // POST: Desserts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dessert = await _repository.GetDessertAsync(id);
            await _repository.DeleteAsync(dessert);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DessertExists(int id)
        {
            return await _repository.DessertExistsAsync(id);
        }
    }
}
