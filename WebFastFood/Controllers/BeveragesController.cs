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
    public class BeveragesController : Controller
    {
        private readonly ILogger<BeveragesController> _logger;
        private IBeverageRepository _repository;
        public BeveragesController(ILogger<BeveragesController> logger, IBeverageRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: Beverages
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetBeveragesAsync());
        }
        // GET: Beverages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var beverage = await _repository.GetBeverageAsync((int)id);
            if (beverage == null) return NotFound();
            return View(beverage);
        }
        // GET: Beverages/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Beverages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Millimeter,IsCarbonated,Id,Name,Price,Description")] Beverage beverage)
        {
            if (ModelState.IsValid){
               await _repository.CreateAsync(beverage);
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }
        // GET: Beverages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var beverage = await _repository.GetBeverageAsync((int)id);
            if (beverage == null) return NotFound();
            return View(beverage);
        }
        // POST: Beverages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Millimeter,IsCarbonated,Id,Name,Price,Description")] Beverage beverage)
        {
            if (id != beverage.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(beverage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeverageExists(beverage.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }
        // GET: Beverages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var beverage = await _repository.GetBeverageAsync((int)id);
            if (beverage == null) return NotFound();
            return View(beverage);
        }
        // POST: Beverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beverage = await _repository.GetBeverageAsync(id);
            await _repository.DeleteAsync(beverage);
            return RedirectToAction(nameof(Index));
        }
        private bool BeverageExists(int id)
        {
            return _repository.GetBeveragesAsync().Result.Any(e => e.Id == id);
        }
    }
}
