using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerDonorAssignment.Data;
using VolunteerDonorAssignment.Models;

namespace VolunteerDonorAssignment.Controllers  //This will be the controller to handle the logic of the pages used by logged in Employees.
                                                //Such as adding and updating Donor information and assigning Donors. 
{
    public class EmployeeController : Controller
    {
        private readonly AzureSQLContext _db; //Allows you to access information in the database
        public EmployeeController(AzureSQLContext db)
        {
            _db = db;
        }
        public IActionResult Index() //You can right click on IActionResult or Index() to "Add View..."
        {
            IEnumerable<Donor> objList = _db.Donors; //Temporarily doing this until I find a way to pass donor information to the Volunteer model
            return View(objList);
        }
        [HttpGet]
        public IActionResult AddDonor()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDonor(Donor obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            _db.Donors.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.Donors.Find(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Donor obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            _db.Donors.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id==0)
                return NotFound();

            var obj = _db.Donors.Find(id);

            if (obj == null)
                return NotFound();
            
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? DonorId) //Parameter needs to be the same name as the Id of the table
        {
            var obj = _db.Donors.Find(DonorId);
            if (obj == null)
                return NotFound();                    

            _db.Donors.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
