using System.Diagnostics;
using CleanArchaticture.Application.Common.Interfaces;
using CleanArchaticture.Models;
using CleanArchaticture.View_model;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchaticture.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                VillaList = _unitOfWork.Villa.GetAll(IncludeProperties: "Amenities"),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now)
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
            // return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
