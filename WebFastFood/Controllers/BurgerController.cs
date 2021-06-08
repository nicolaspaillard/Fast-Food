using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Repository.IRepositories;

namespace WebFastFood.Controllers
{
    public class BurgerController : Controller
    {
        private readonly ILogger<BurgerController> _logger;
        private IFastFoodRepository _repository;

        public BurgerController(ILogger<BurgerController> logger, IFastFoodRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: BurgerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BurgerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BurgerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BurgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BurgerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BurgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BurgerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BurgerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
