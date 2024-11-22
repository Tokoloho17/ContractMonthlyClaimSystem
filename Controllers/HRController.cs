using ContractMonthlyClaimSystem.Data;
using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class HRController : Controller
    {
        private readonly AppDbContext _context;

        public HRController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /HR/HRManagement
        public IActionResult HRManagement()
        {
            var approvedClaims = _context.Claims.Where(c => c.Status == "Approved").ToList();
            return View(approvedClaims);
        }

        // POST: /HR/GenerateInvoice
        [HttpPost]
        public IActionResult GenerateInvoice(int claimId)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.Id == claimId);
            if (claim == null)
            {
                return NotFound();
            }

            // Explicitly cast the TotalAmount to decimal
            var invoice = new Invoice
            {
                LecturerId = claim.LecturerId,
                ClaimId = claim.Id,
                TotalAmount = (decimal)claim.TotalAmount,  // Explicit cast from double to decimal
                InvoiceDate = DateTime.Now
            };

            // Add the invoice to the database
            _context.Invoices.Add(invoice);  // Ensure the DbSet<Invoice> exists in AppDbContext
            _context.SaveChanges();

            return RedirectToAction(nameof(HRManagement));
        }

        // POST: /HR/UpdateLecturerData
        [HttpPost]
        public IActionResult UpdateLecturerData(int lecturerId, Lecturer updatedLecturer)
        {
            if (updatedLecturer == null)
            {
                return BadRequest("Lecturer data is missing.");
            }

            var lecturer = _context.Lecturers.FirstOrDefault(l => l.Id == lecturerId);
            if (lecturer == null)
            {
                return NotFound();
            }

            lecturer.Name = updatedLecturer.Name;
            lecturer.Email = updatedLecturer.Email;

            if (!ModelState.IsValid)
            {
                return View(updatedLecturer);
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(HRManagement));
        }
    }
}
