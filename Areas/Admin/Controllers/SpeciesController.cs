using Microsoft.AspNetCore.Mvc;
using AlabAqua.Core.Interfaces;
using AlabAqua.Application.ViewModels.Species;
using AlabAqua.Core.Entities;

namespace AlabAqua.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeciesController : Controller
    {
        private readonly ISpeciesRepository _speciesRepo;

        public SpeciesController(ISpeciesRepository speciesRepo)
        {
            _speciesRepo = speciesRepo;
        }

        public async Task<IActionResult> Index()
        {
            var species = await _speciesRepo.GetAllAsync();

            var vm = species.Select(s => new SpeciesViewModel
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName,
                Description = s.Description
            }).ToList();

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpeciesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var entity = new Species
            {
                CommonName = model.CommonName,
                ScientificName = model.ScientificName,
                Description = model.Description
            };

            await _speciesRepo.AddAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var species = await _speciesRepo.GetByIdAsync(id);
            if (species == null)
                return NotFound();

            var vm = new SpeciesViewModel
            {
                Id = species.Id,
                CommonName = species.CommonName,
                ScientificName = species.ScientificName,
                Description = species.Description
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SpeciesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var entity = await _speciesRepo.GetByIdAsync(model.Id);
            if (entity == null)
                return NotFound();

            entity.CommonName = model.CommonName;
            entity.ScientificName = model.ScientificName;
            entity.Description = model.Description;

            await _speciesRepo.UpdateAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var species = await _speciesRepo.GetByIdAsync(id);
            if (species == null)
                return NotFound();

            await _speciesRepo.DeleteAsync(species);
            return RedirectToAction("Index");
        }
    }
}
