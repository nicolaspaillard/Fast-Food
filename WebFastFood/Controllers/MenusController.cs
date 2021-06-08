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
    public class MenusController : Controller
    {
        private readonly ILogger<MenusController> _logger;
        private IMenuRepository _repository;
        private IBeverageRepository _beverages;
        private IBurgerRepository _burgers;
        private IDessertRepository _desserts;
        private ISideRepository _sides;
        public MenusController(ILogger<MenusController> logger, IMenuRepository repository, IBeverageRepository beverages, IBurgerRepository burgers, IDessertRepository desserts, ISideRepository sides)
        {
            _logger = logger;
            _repository = repository;
            _beverages = beverages;
            _burgers = burgers;
            _desserts = desserts;
            _sides = sides;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetMenusAsync());
        }

        // GET: Menus/Details/5
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

        // GET: Menus/Create
        public IActionResult Create()
        {
            ViewData["Burgers"] = _burgers.GetBurgersAsync().Result.Select(x =>
                      new SelectListItem()
                      {
                          Text = x.Name,
                          Value = x.Id.ToString()
                      }).ToList();
            ViewData["Sides"] = _sides.GetSidesAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Beverages"] = _beverages.GetBeveragesAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Desserts"] = _desserts.GetDessertsAsync().Result.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Burger,Side,Beverage,Dessert")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.Burger = await _burgers.GetBurgerAsync(menu.Burger.Id);
                menu.Side = await _sides.GetSideAsync(menu.Side.Id);
                menu.Beverage = await _beverages.GetBeverageAsync(menu.Beverage.Id);
                menu.Dessert = await _desserts.GetDessertAsync(menu.Dessert.Id);
                await _repository.CreateAsync(menu);
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["Burgers"] = (await _burgers.GetBurgersAsync()).Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Sides"] = (await _sides.GetSidesAsync()).Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Beverages"] = (await _beverages.GetBeveragesAsync()).Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Desserts"] = (await _desserts.GetDessertsAsync()).Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    menu.Burger = await _burgers.GetBurgerAsync(menu.Burger.Id);
                    menu.Side = await _sides.GetSideAsync(menu.Side.Id);
                    menu.Beverage = await _beverages.GetBeverageAsync(menu.Beverage.Id);
                    menu.Dessert = await _desserts.GetDessertAsync(menu.Dessert.Id);
                    _repository.UpdateAsync(menu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _repository.GetMenuAsync(id);
            await _repository.DeleteAsync(menu);
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _repository.GetMenusAsync().Result.Any(m => m.Id == id);
        }
    }
}
