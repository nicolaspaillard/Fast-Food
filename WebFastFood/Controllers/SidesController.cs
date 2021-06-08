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
    public class SidesController : Controller
    {
        private readonly ILogger<SidesController> _logger;
        private IFastFoodRepository _repository;
        public SidesController(ILogger<SidesController> logger, IFastFoodRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: GetSides()
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetSides().ToListAsync());
        }

        // GET: GetSides()/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var side = await _repository.GetSides()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (side == null)
            {
                return NotFound();
            }

            return View(side);
        }

        // GET: GetSides()/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GetSides()/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Side side)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(side);
                return RedirectToAction(nameof(Index));
            }
            return View(side);
        }

        // GET: GetSides()/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var side = _repository.GetSide((int)id);
            if (side == null)
            {
                return NotFound();
            }
            return View(side);
        }

        // POST: GetSides()/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Side side)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(side);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(_repository.GetSide(side.Id));
                }

            }
            return View(_repository.GetSide(side.Id));
        }

        // GET: GetSides()/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var side = _repository.GetSide((int)id);
            if (side == null)
            {
                return NotFound();
            }
            _repository.Delete(side);
            return RedirectToAction(nameof(Index));
        }
    }
}
