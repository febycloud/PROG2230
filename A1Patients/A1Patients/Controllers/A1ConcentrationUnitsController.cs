using A1Patients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace A1Patients.Controllers
{
    public class A1ConcentrationUnitsController : Controller
    {
        private readonly PatientsContext _context;

        // Constructor of the Controller class
        public A1ConcentrationUnitsController(PatientsContext context)
        {
            _context = context;
        }

        // GET: A1ConcentrationUnits
        // Gets the list of all Concentration Units from database
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConcentrationUnit.ToListAsync());
        }

        // GET: A1ConcentrationUnits/Details/5
        // Gets the detail of the Concentration Unit corresponding to the id passed as a parameter
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concentrationUnit = await _context.ConcentrationUnit
                .FirstOrDefaultAsync(m => m.ConcentrationCode == id);
            if (concentrationUnit == null)
            {
                return NotFound();
            }

            return View(concentrationUnit);
        }

        // GET: A1ConcentrationUnits/Create
        // This action is called when Create action is called fist time. 
        // This action is returing to the default view
        public IActionResult Create()
        {
            return View();
        }

        // POST: A1ConcentrationUnits/Create
        // This Post method recieves Concentration Unit object from the view. This object would have the current state of the view
        // New Concentration Unit entry would be created, reading the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcentrationCode")] ConcentrationUnit concentrationUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concentrationUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concentrationUnit);
        }

        // GET: A1ConcentrationUnits/Edit/5
        // Default Edit action. Will be called first time the Edit action is called.
        // Parameter id is passed which is used to fetch the particular Concentration Unit record for edit operation.
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concentrationUnit = await _context.ConcentrationUnit.FindAsync(id);
            if (concentrationUnit == null)
            {
                return NotFound();
            }
            return View(concentrationUnit);
        }

        // POST: A1ConcentrationUnits/Edit/5
        // This Post method recieves Concentration Unit object from the view. This object would have the current state of the view
        // Existing Concentration Unit entry would be updated as per the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConcentrationCode")] ConcentrationUnit concentrationUnit)
        {
            if (id != concentrationUnit.ConcentrationCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concentrationUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcentrationUnitExists(concentrationUnit.ConcentrationCode))
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
            return View(concentrationUnit);
        }

        // GET: A1ConcentrationUnits/Delete/5
        // Default action for the delete. Will be called first time the delete action is called.
        // Parameter id is passed which is used to fetch the particular Concentration Unit record for delete operation.
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concentrationUnit = await _context.ConcentrationUnit
                .FirstOrDefaultAsync(m => m.ConcentrationCode == id);
            if (concentrationUnit == null)
            {
                return NotFound();
            }

            return View(concentrationUnit);
        }

        // POST: A1ConcentrationUnits/Delete/5
        // Post Delete action. This is called as soon as user presses the Delete button on the View.
        // Concentration Unit corresponding to the id (passed as parameter) will be deleted from the database.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var concentrationUnit = await _context.ConcentrationUnit.FindAsync(id);
            _context.ConcentrationUnit.Remove(concentrationUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // This function is used to check if particular Concentration Unit exists in the database or not
        private bool ConcentrationUnitExists(string id)
        {
            return _context.ConcentrationUnit.Any(e => e.ConcentrationCode == id);
        }
    }
}
