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
using WebFastFood.Models;

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
        private ProductsViewModel _productsViewModel = new();
        public MenusController(ILogger<MenusController> logger, IMenuRepository repository, IBeverageRepository beverages, IBurgerRepository burgers, IDessertRepository desserts, ISideRepository sides)
        {
            _logger = logger;
            _repository = repository;
            _beverages = beverages;
            _burgers = burgers;
            _desserts = desserts;
            _sides = sides;
            _productsViewModel.Burgers.Add(new() { Text = "Pas de burger", Value = "-1" });
            _productsViewModel.Burgers.AddRange(_burgers.GetBurgersAsync().Result.Select(x => new SelectListItem(){Text = x.Name,Value = x.Id.ToString()}).ToList());
            _productsViewModel.Beverages.Add(new() { Text = "Pas de boisson", Value = "-1" });
            _productsViewModel.Beverages.AddRange(_beverages.GetBeveragesAsync().Result.Select(x => new SelectListItem(){Text = x.Name,Value = x.Id.ToString()}).ToList());
            _productsViewModel.Sides.Add(new() { Text = "Pas d'accompagnement", Value = "-1" });
            _productsViewModel.Sides.AddRange(_sides.GetSidesAsync().Result.Select(x => new SelectListItem(){Text = x.Name,Value = x.Id.ToString()}).ToList());
            _productsViewModel.Desserts.Add(new() { Text = "Pas de dessert", Value="-1"});
            _productsViewModel.Desserts.AddRange(_desserts.GetDessertsAsync().Result.Select(x =>new SelectListItem(){Text = x.Name,Value = x.Id.ToString()}).ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetMenusAsync());
        }
        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var menu = await _repository.GetMenuAsync((int)id);
            if (menu == null) return NotFound();
            return View(menu);
        }
        // GET: Menus/Create
        public IActionResult Create()
        {
            return View(_productsViewModel);
        }
        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Description,Burger,Side,Beverage,Dessert")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(await GetMenu(menu));
                return RedirectToAction(nameof(Index));
            }
            return View(_productsViewModel);
        }
        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var menu = await _repository.GetMenuAsync((int)id);
            if (menu == null) return NotFound();
            _productsViewModel.Menu = menu;
            return View(_productsViewModel);
        }
        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Burger,Side,Beverage,Dessert")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(await GetMenu(menu));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MenuExists(menu.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }
        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var menu = await _repository.GetMenuAsync((int)id);
            if (menu == null) return NotFound();
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
        private async Task<bool> MenuExists(int id)
        {
            return await _repository.MenuExistsAsync(id);
        }
        public async Task<Menu> GetMenu(Menu menu)
        {
            if (menu.Burger.Id != -1) menu.Burger = await _burgers.GetBurgerAsync(menu.Burger.Id);
            else menu.Burger = null;
            if (menu.Side.Id != -1)menu.Side = await _sides.GetSideAsync(menu.Side.Id);
            else menu.Side = null;
            if (menu.Beverage.Id != -1) menu.Beverage = await _beverages.GetBeverageAsync(menu.Beverage.Id);
            else menu.Beverage = null;
            if (menu.Dessert.Id != -1) menu.Dessert = await _desserts.GetDessertAsync(menu.Dessert.Id);
            else menu.Dessert = null;
            return menu;
        }
    }
}
