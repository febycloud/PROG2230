using A1Patients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace A1Patients.Controllers
{
    public class A1DispensingUnitsController : Controller
    {
        private readonly PatientsContext _context;

        // Constructor of the Controller class
        public A1DispensingUnitsController(PatientsContext context)
        {
            _context = context;
        }

        // GET: A1DispensingUnits
        // Gets the list of all Dispensing Units from database
        public async Task<IActionResult> Index()
        {
            return View(await _context.DispensingUnit.ToListAsync());
        }

        // GET: A1DispensingUnits/Details/5
        // Gets the Dispensing Unit corresponding to the id passed as a parameter
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispensingUnit = await _context.DispensingUnit
                .FirstOrDefaultAsync(m => m.DispensingCode == id);
            if (dispensingUnit == null)
            {
                return NotFound();
            }

            return View(dispensingUnit);
        }

        // GET: A1DispensingUnits/Create
        // This action is called when Create action is called fist time. 
        // This action is returing to the default view
        public IActionResult Create()
        {
            return View();
        }

        // POST: A1DispensingUnits/Create
        // This Post method recieves Dispensing Unit object from the view. This object would have the current state of the view
        // New Dispensing Unit entry would be created, reading the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DispensingCode")] DispensingUnit dispensingUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dispensingUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dispensingUnit);
        }

        // GET: A1DispensingUnits/Edit/5
        // Default Edit action. Will be called first time the Edit action is called.
        // Parameter id is passed which is used to fetch the particular Dispensing Unit record for edit operation.
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispensingUnit = await _context.DispensingUnit.FindAsync(id);
            if (dispensingUnit == null)
            {
                return NotFound();
            }
            return View(dispensingUnit);
        }

        // POST: A1DispensingUnits/Edit/5
        // This Post method recieves Dispensing Unit object from the view. This object would have the current state of the view
        // Existing Dispensing Unit entry would be updated as per the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DispensingCode")] DispensingUnit dispensingUnit)
        {
            if (id != dispensingUnit.DispensingCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispensingUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DispensingUnitExists(dispensingUnit.DispensingCode))
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
            return View(dispensingUnit);
        }

        // GET: A1DispensingUnits/Delete/5
        // Default action for the delete.Will be called first time the delete action is called.
        // Parameter id is passed which is used to fetch the particular Dispensing Unit record for delete operation.
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispensingUnit = await _context.DispensingUnit
                .FirstOrDefaultAsync(m => m.DispensingCode == id);
            if (dispensingUnit == null)
            {
                return NotFound();
            }

            return View(dispensingUnit);
        }

        // POST: A1DispensingUnits/Delete/5
        // Post Delete action. This is called as soon as user presses the Delete button on the View.
        // Dispensing Unit corresponding to the id (passed as parameter) will be deleted from the database.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dispensingUnit = await _context.DispensingUnit.FindAsync(id);
            _context.DispensingUnit.Remove(dispensingUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // This function is used to check if particular Dispensing Unit exists in the database or not
        private bool DispensingUnitExists(string id)
        {
            return _context.DispensingUnit.Any(e => e.DispensingCode == id);
        }
    }
}
