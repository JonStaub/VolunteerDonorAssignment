using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerDonorAssignment.Data;
using VolunteerDonorAssignment.Models;

namespace VolunteerDonorAssignment.Controllers 
{
    public class VolunteerController : Controller
    {
        private readonly AzureSQLContext _db; 
        public VolunteerController(AzureSQLContext db)
        {
            _db = db;
        }
        public IActionResult Index() 
        {
            IEnumerable<Donor> objList = _db.Donors; 
            return View(objList);
        }
        [HttpGet]
        public IActionResult AdjustDonorInfo()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdjustDonorInfo(Donor donor)
        {
            if (!ModelState.IsValid)
                return View(donor);

            _db.Donors.Add(donor);
            _db.SaveChanges();   
            return RedirectToAction("Index");
        }
    }
}