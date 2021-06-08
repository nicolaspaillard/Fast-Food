using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Repository.IRepositories;

namespace WebFastFood.Controllers
{
    public class MenusController_bkp : Controller
    {
        private readonly ILogger<MenusController_bkp> _logger;
        private IFastFoodRepository _repository;
        public MenusController_bkp(ILogger<MenusController_bkp> logger, IFastFoodRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: MenuController
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetMenusAsync());
        }

        // GET: MenuController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var menu = await _repository.GetMenuAsync((int)id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: MenuController/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Burgers"] = _repository.GetBurgersAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Sides"] = _repository.GetSidesAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Beverages"] = _repository.GetBeveragesAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Desserts"] = _repository.GetDessertsAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            return View();
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Menu menu)
        {
            try
            { 
                menu.Burger = _repository.GetBurgerAsync(menu.Burger.Id).Result;
                menu.Side = _repository.GetSideAsync(menu.Side.Id).Result;
                menu.Beverage = _repository.GetBeverageAsync(menu.Beverage.Id).Result;
                menu.Dessert = _repository.GetDessertAsync(menu.Dessert.Id).Result;
                _repository.CreateAsync(menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Burgers"] = _repository.GetBurgersAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Sides"] = _repository.GetSidesAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Beverages"] = _repository.GetBeveragesAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Desserts"] = _repository.GetDessertsAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            if (id == null)
            {
                return NotFound();
            }

            var menu = _repository.GetMenuAsync((int)id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    menu.Burger = _repository.GetBurgerAsync(menu.Burger.Id).Result;
                    menu.Side = _repository.GetSideAsync(menu.Side.Id).Result;
                    menu.Beverage = _repository.GetBeverageAsync(menu.Beverage.Id).Result;
                    menu.Dessert = _repository.GetDessertAsync(menu.Dessert.Id).Result;
                    _repository.UpdateAsync(menu);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(_repository.GetMenuAsync(menu.Id));
                }
            }
            return View(_repository.GetMenuAsync(menu.Id));
        }

        // GET: MenuController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _repository.GetMenuAsync((int)id).Result;
            if (menu == null)
            {
                return NotFound();
            }
            _repository.DeleteAsync(menu);
            return RedirectToAction(nameof(Index));
        }
    }
}
