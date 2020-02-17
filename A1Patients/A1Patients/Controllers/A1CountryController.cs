using A1Patients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace A1Patients.Controllers
{
    public class A1CountryController : Controller
    {
        private readonly PatientsContext _context;

        // Constructor of the Controller class
        public A1CountryController(PatientsContext context)
        {
            _context = context;
        }

        // GET: A1Country
        // Gets the list of all countries from database
        public async Task<IActionResult> Index()
        {
            return View(await _context.Country.ToListAsync());
        }

        // GET: A1Country/Details/5
        // Gets the country corresponding to the id passed as a parameter
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.CountryCode == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: A1Country/Create
        // This action is called when Create action is called fist time. 
        // This action is returing to the default view
        public IActionResult Create()
        {
            return View();
        }

        // POST: A1Country/Create
        // This Post method recieves country object from the view. This object would have the current state of the view
        // New country entry would be created, reading the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryCode,Name,PostalPattern,PhonePattern,FederalSalesTax")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: A1Country/Edit/5
        // Default Edit action. Will be called first time the Edit action is called.
        // Parameter id is passed which is used to fetch the particular country record for edit operation.
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: A1Country/Edit/5
        // This Post method recieves country object from the view. This object would have the current state of the view
        // Existing country entry would be updated as per the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CountryCode,Name,PostalPattern,PhonePattern,FederalSalesTax")] Country country)
        {
            if (id != country.CountryCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryCode))
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
            return View(country);
        }

        // GET: A1Country/Delete/5
        // Default action for the delete.Will be called first time the delete action is called.
        // Parameter id is passed which is used to fetch the particular country record for delete operation.
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.CountryCode == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: A1Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // Post Delete action. This is called as soon as user presses the Delete button on the View.
        // Country corresponding to the id (passed as parameter) will be deleted from the database.
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var country = await _context.Country.FindAsync(id);
            _context.Country.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // This function is used to check if particular country exists in the database or not
        private bool CountryExists(string id)
        {
            return _context.Country.Any(e => e.CountryCode == id);
        }
    }
}
