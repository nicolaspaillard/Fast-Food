using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using Models;
using WebFastFood.Repository.IRepositories;
using Microsoft.Extensions.Logging;

namespace WebFastFood.Controllers
{
    public class SidesController : Controller
    {
        private readonly ILogger<SidesController> _logger;
        private ISideRepository _repository;
        public SidesController(ILogger<SidesController> logger, ISideRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: Sides
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetSidesAsync());
        }

        // GET: Sides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var side = await _repository.GetSideAsync((int)id);
            if (side == null) return NotFound();
            return View(side);
        }

        // GET: Sides/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Weight,SaltWeight,Id,Name,Price,Description")] Side side)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(side);
                return RedirectToAction(nameof(Index));
            }
            return View(side);
        }

        // GET: Sides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var side = await _repository.GetSideAsync((int)id);
            if (side == null) return NotFound();
            return View(side);
        }

        // POST: Sides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Weight,SaltWeight,Id,Name,Price,Description")] Side side)
        {
            if (id != side.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(side);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SideExists(side.Id)) return NotFound(); 
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(side);
        }

        // GET: Sides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var side = await _repository.GetSideAsync((int)id);
            if (side == null) return NotFound();
            return View(side);
        }

        // POST: Sides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var side = await _repository.GetSideAsync(id);
            await _repository.DeleteAsync(side);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SideExists(int id)
        {
            return await _repository.SideExistsAsync(id);
        }
    }
}
