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
    public class BurgersController : Controller
    {
        private readonly ILogger<BurgersController> _logger;
        private IBurgerRepository _repository;
        public BurgersController(ILogger<BurgersController> logger, IBurgerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: Burgers
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetBurgersAsync());
        }
        // GET: Burgers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burger = await _repository.GetBurgerAsync((int)id);
            if (burger == null)
            {
                return NotFound();
            }

            return View(burger);
        }
        // GET: Burgers/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Burgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Weight,BeefWeight,Id,Name,Price,Description")] Burger burger)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateAsync(burger);
                return RedirectToAction(nameof(Index));
            }
            return View(burger);
        }
        // GET: Burgers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burger = await _repository.GetBurgerAsync((int)id);
            if (burger == null)
            {
                return NotFound();
            }
            return View(burger);
        }
        // POST: Burgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Weight,BeefWeight,Id,Name,Price,Description")] Burger burger)
        {
            if (id != burger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateAsync(burger);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurgerExists(burger.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(burger);
        }
        // GET: Burgers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burger = await _repository.GetBurgerAsync((int)id);
            if (burger == null)
            {
                return NotFound();
            }

            return View(burger);
        }
        // POST: Burgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burger = await _repository.GetBurgerAsync(id);
            await _repository.DeleteAsync(burger);
            return RedirectToAction(nameof(Index));
        }
        private bool BurgerExists(int id)
        {
            return _repository.GetBurgersAsync().Result.Any(e => e.Id == id);
        }
    }
}
