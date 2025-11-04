using CleanArchaticture.Application.Common.Interfaces;
using CleanArchaticture.Domain.Model;
using CleanArchaticture.Infrastructure.Data;
using CleanArchaticture.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Net.Mime;
using System.Security.AccessControl;

namespace CleanArchaticture.Controllers
{
    
    public class AmenityController : Controller
    {
      private readonly IUnitOfWork _IunitOfWork;
        public AmenityController(IUnitOfWork iunitOfWork)
        {
          _IunitOfWork = iunitOfWork;
        }
        public IActionResult Index()
        {
            //var Amenitys = _context.Amenitys.ToList();
            //after include

            var Amenitys = _IunitOfWork.Amenity.GetAll(IncludeProperties: "Villa");
            return View(Amenitys);
        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> list = _IunitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()

            });

            ViewBag.Villalist = list;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Amenity objNumbers)
        {
            ModelState.Remove("Villa");
            if (ModelState.IsValid)
            {
                _IunitOfWork.Amenity.Add(objNumbers);
                _IunitOfWork.Save();
                TempData["success"] = "The Villa Has been Created Successfully";
                return RedirectToAction("Index");
            }

            else
            //TempData["error"] = "The Villa Could'nt be created";
            return View(objNumbers);
        }

        [HttpGet]
                public IActionResult Update(int id)

                {
                    var obj = _IunitOfWork.Amenity.Get(x => x.Id == id, IncludeProperties: "Villa");

                    if (obj==null)
                    {
                        return NotFound();
                    }

                    ViewBag.Villalist = _IunitOfWork.Villa.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString() 
                    });

                    return View(obj);


                    //before unitofwork

                    //// Villa? obj = _context.villas.FirstOrDefault(x => x.Id == id);
                    ////get data from feild by ID
                    //Amenitys? obj = _IunitOfWork.Amenitys.Get(x => x.Amenity == id);
                    //if (obj == null)
                    //{
                    //    return RedirectToAction("Error", "Home");
                    //}

                    ////get data from model to show it in drwodown list
                    //ViewBag.Villalist = _IunitOfWork.Villa.GetAll().Select(u => new SelectListItem
                    //    {
                    //        Text = u.Name,
                    //        Value = u.Id.ToString()

                    //    });






                    //return View(obj); 
                }

                [HttpPost]

                public IActionResult Update(Amenity obNumbers)
                {


                    if (ModelState.IsValid)
                    {
                        var VillanumberfromDB =
                            _IunitOfWork.Amenity.Get(u => u.Id == obNumbers.Id);
                        if (VillanumberfromDB==null)
                        {
                            return NotFound();
                        }
                        VillanumberfromDB.Id=obNumbers.Id;
                        VillanumberfromDB.Name=obNumbers.Name;

                            _IunitOfWork.Amenity.Update(VillanumberfromDB);
                            _IunitOfWork.Save();

                        //before using UnitOfWork

                        //_IunitOfWork.Amenitys.Update(obNumbers);
                        //_IunitOfWork.Save();
                        //return RedirectToAction("Index");





            }
                              //dropdown 
                                ViewBag.Villalist = _IunitOfWork.Villa.GetAll().Select(x => new SelectListItem
                                {
                                    Text = x.Name,
                                    Value = x.Id.ToString()
                                    

                                });

                           return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {
            var obj = _IunitOfWork.Amenity.Get(x=>x.Id==id);
            if (obj!=null)
            {
                _IunitOfWork.Amenity.Remove(obj);
                TempData["success"] = "The Villa Has been Deleted Successfully";
                _IunitOfWork.Save();

            }
            else
            {
                TempData["error"] = "The Villa could'nt be Deleted";
                
            }
                return RedirectToAction("Index"); 

        }
    }
}
