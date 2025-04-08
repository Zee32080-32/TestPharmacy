using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;

namespace PharmacyApp.Controllers
{
    public class FeedbackFormsController : Controller
    {
        private readonly ApplicationdbContext _context;

        public FeedbackFormsController(ApplicationdbContext context)
        {
            _context = context;
        }

        // GET: FeedbackForms
        public async Task<IActionResult> Index()
        {
            var applicationdbContext = _context.FeedbackForm.Include(f => f.customers);
            return View(await applicationdbContext.ToListAsync());
        }

        // GET: FeedbackForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackForm = await _context.FeedbackForm
                .Include(f => f.customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedbackForm == null)
            {
                return NotFound();
            }

            return View(feedbackForm);
        }

        // GET: FeedbackForms/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: FeedbackForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CustomerID")] FeedbackForm feedbackForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbackForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Users, "Id", "Id", feedbackForm.CustomerID);
            return View(feedbackForm);
        }

        // GET: FeedbackForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackForm = await _context.FeedbackForm.FindAsync(id);
            if (feedbackForm == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Users, "Id", "Id", feedbackForm.CustomerID);
            return View(feedbackForm);
        }

        // POST: FeedbackForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CustomerID")] FeedbackForm feedbackForm)
        {
            if (id != feedbackForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbackForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackFormExists(feedbackForm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Users, "Id", "Id", feedbackForm.CustomerID);
            return View(feedbackForm);
        }

        // GET: FeedbackForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackForm = await _context.FeedbackForm
                .Include(f => f.customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedbackForm == null)
            {
                return NotFound();
            }

            return View(feedbackForm);
        }

        // POST: FeedbackForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedbackForm = await _context.FeedbackForm.FindAsync(id);
            if (feedbackForm != null)
            {
                _context.FeedbackForm.Remove(feedbackForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackFormExists(int id)
        {
            return _context.FeedbackForm.Any(e => e.Id == id);
        }
    }
}
