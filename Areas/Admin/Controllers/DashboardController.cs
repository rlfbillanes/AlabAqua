using Microsoft.AspNetCore.Mvc;
using AlabAqua.Core.Interfaces;
using AlabAqua.Application.ViewModels.Admin;

namespace AlabAqua.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ISpeciesRepository _speciesRepo;
        private readonly IUserRepository _userRepo;
        private readonly ITankRepository _tankRepo;

        public DashboardController(
            ISpeciesRepository speciesRepo,
            IUserRepository userRepo,
            ITankRepository tankRepo)
        {
            _speciesRepo = speciesRepo;
            _userRepo = userRepo;
            _tankRepo = tankRepo;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new DashboardViewModel
            {
                TotalSpecies = (await _speciesRepo.GetAllAsync()).Count(),
                TotalUsers = (await _userRepo.GetAllAsync()).Count(),
                TotalTanks = (await _tankRepo.GetAllAsync()).Count()
            };

            return View(vm);
        }
    }
}
