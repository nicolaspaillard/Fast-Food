using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // GET: BurgerController
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetBurgersAsync());
        }

        // GET: BurgerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _repository.GetBurgerAsync(id));
        }

        // GET: BurgerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BurgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Burger burger)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateAsync(burger);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: BurgerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var burger = await _repository.GetBurgerAsync((int)id);
            return View(burger);
        }

        // POST: BurgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Burger burger)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateAsync(burger);
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: BurgerController/Delete/5
        public ActionResult Delete(Burger burger)
        {
            return View();
        }

        // POST: BurgerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var burger = await _repository.GetBurgerAsync(id);
                _repository.DeleteAsync(burger);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
