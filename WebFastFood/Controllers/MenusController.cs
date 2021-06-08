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
    public class MenusController : Controller
    {
        private readonly ILogger<MenusController> _logger;
        private IFastFoodRepository _repository;
        public MenusController(ILogger<MenusController> logger, IFastFoodRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: MenuController
        public ActionResult Index()
        {
            return View(_repository.GetMenus().ToList());
        }

        // GET: MenuController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetMenus().First(m => m.Id == id));
        }

        // GET: MenuController/Create
        public ActionResult Create()
        {
            ViewData["Burgers"] = _repository.GetBurgers().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Sides"] = _repository.GetSides().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Beverages"] = _repository.GetBeverages().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Desserts"] = _repository.GetDesserts().Select(x =>
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
        public ActionResult Create(Menu menu)
        {
            try
            {
                menu.Burger = _repository.GetBurgers().First(b => b.Id == menu.Burger.Id);
                menu.Side = _repository.GetSides().First(s => s.Id == menu.Side.Id);
                menu.Beverage = _repository.GetBeverages().First(s => s.Id == menu.Beverage.Id);
                menu.Dessert = _repository.GetDesserts().First(s => s.Id == menu.Dessert.Id);
                _repository.AddMenu(menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["Burgers"] = _repository.GetBurgers().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Sides"] = _repository.GetSides().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Beverages"] = _repository.GetBeverages().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["Desserts"] = _repository.GetDesserts().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            return View(_repository.GetMenus().First(m => m.Id == id));
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Menu menu)
        {
            try
            {
                menu.Burger = _repository.GetBurgers().First(b => b.Id == menu.Burger.Id);
                menu.Side = _repository.GetSides().First(s => s.Id == menu.Side.Id);
                menu.Beverage = _repository.GetBeverages().First(s => s.Id == menu.Beverage.Id);
                menu.Dessert = _repository.GetDesserts().First(s => s.Id == menu.Dessert.Id);
                _repository.EditMenu(id, menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_repository.GetMenus().First(m => m.Id == id));
            }
        }

        // GET: MenuController/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.DeleteMenu(_repository.GetMenus().First(m => m.Id == id));
            return RedirectToAction(nameof(Index));
        }
    }
}
