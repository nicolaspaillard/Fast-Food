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
        public ActionResult Index()
        {
            return View(_repository.GetBurgers());
        }

        // GET: BurgerController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetBurger(id));
        }

        // GET: BurgerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BurgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Burger burger)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddBurger(burger);
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
        public ActionResult Edit(int id)
        {
            var burger = _repository.GetBurger(id);
            return View(burger);
        }

        // POST: BurgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Burger burger)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.EditBurger(burger);
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
        public ActionResult Delete(int id)
        {
            try
            {
                var burger = _repository.GetBurger(id);
                _repository.DeleteBurger(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
