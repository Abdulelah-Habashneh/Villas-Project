using CleanArchaticture.Application.Common.Interfaces;
using CleanArchaticture.Domain.Model;
using CleanArchaticture.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.AccessControl;

namespace CleanArchaticture.Controllers
{
    
    public class VillaController : Controller
    {
      private readonly IUnitOfWork _IunitOfWork; //to deal with database
      private readonly IWebHostEnvironment _webHostEnvironment;//to deal with images and add it
    

        public VillaController(IUnitOfWork iunitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this._IunitOfWork = iunitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var villas = _IunitOfWork.Villa.GetAll();
            return View(villas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa villa)    
        {
            if (villa.Name == villa.Description)
            {
                    ModelState.AddModelError("","The Name and Description can't be the same");
            }   

            if (ModelState.IsValid)
            {

                if ( villa.Image!=null)
                {

                    //to add image in create form
                    //1 open folder in wwwroot
                    //2 add fake enetity and make it(Not Mapped) 
                    //3 create this code(Above ) 
                    //4 put feild for it in view 


                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                    string imagepath = Path.Combine(_webHostEnvironment.WebRootPath, @"Image\VillaImage");
                    using (var fileStream =new FileStream(Path.Combine(imagepath,fileName),FileMode.Create))
                    {
                        villa.Image.CopyTo(fileStream);
                    }

                    villa.ImageUrl = @"\Image\VillaImage" + fileName;
                }
                else
                {
                    villa.ImageUrl = "https://placehold.co/600x400";
                }


                _IunitOfWork.Villa.Add(villa);
                _IunitOfWork.Save();
                TempData["success"] = "The Villa Has been Created Successfully";

                return RedirectToAction("Index");
            }

            else
            TempData["error"] = "The Villa Could'nt be created";
                return View(villa);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
           // Villa? obj = IunitOfWork.villas.FirstOrDefault(x => x.Id == id);
           Villa? obj = _IunitOfWork.Villa.Get(u=>u.Id==id);
          

            if (obj==null)  
            {
                return RedirectToAction("Error","Home");
            }

            return View(obj);
        }

        [HttpPost]

        public IActionResult Update(Villa villa)
        {
           

            if (ModelState.IsValid)
            {
                _IunitOfWork.Villa.Update(villa);
                _IunitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
                return View(villa);



        }

        public IActionResult Delete(int id)
        {
            var obj = _IunitOfWork.Villa.Get(x=>x.Id==id);
            if (obj!=null)
            {
                _IunitOfWork.Villa.Remove(obj);
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
