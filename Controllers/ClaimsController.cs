using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class ClaimsController : Controller
    {
        private static List<Claim> _claims = new List<Claim>();

        // GET: /Claims/Index
        public IActionResult Index()
        {
            return View(_claims);
        }

        // GET: /Claims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Claims/Create
        [HttpPost]
        public IActionResult Create(Claim claim)
        {
            claim.Id = _claims.Count + 1; // Auto-increment ID
            claim.Status = "Pending";    // Default status

            // Ensure the Lecturer property is set before adding the claim
            if (claim.Lecturer != null)
            {
                _claims.Add(claim);
                return RedirectToAction("Index");
            }
            return View(claim);  // Return to Create view if Lecturer is null
        }

        // GET: /Claims/Edit/{id}
        public IActionResult Edit(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            return View(claim);
        }

        // POST: /Claims/Edit
        [HttpPost]
        public IActionResult Edit(Claim updatedClaim)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == updatedClaim.Id);
            if (claim != null)
            {
                claim.Lecturer.Name = updatedClaim.Lecturer.Name;  // Update Lecturer's Name
                claim.HoursWorked = updatedClaim.HoursWorked;
                claim.HourlyRate = updatedClaim.HourlyRate;
                claim.Description = updatedClaim.Description;
                claim.Status = updatedClaim.Status;
            }
            return RedirectToAction("Index");
        }

        // GET: /Claims/Approve/{id}
        public IActionResult Approve(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved"; // Mark as approved
            }
            return RedirectToAction("Index");
        }

        // GET: /Claims/Reject/{id}
        public IActionResult Reject(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected"; // Mark as rejected
            }
            return RedirectToAction("Index");
        }
    }
}
