using A1Patients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace A1Patients.Controllers
{
    public class A1MedicationTypesController : Controller
    {
        private readonly PatientsContext _context;

        // Constructor of the Controller class
        public A1MedicationTypesController(PatientsContext context)
        {
            _context = context;
        }

        // GET: A1MedicationTypes
        // Gets the list of all Medication Types from database
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicationType.ToListAsync()); //orderby medication name
        }

        // GET: A1MedicationTypes/Details/5
        // Gets the Medication Type corresponding to the id passed as a parameter
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var medicationType = await _context.MedicationType
                 .FirstOrDefaultAsync(m => m.MedicationTypeId == id);
             
            if (medicationType == null)
            {
                return NotFound();
            }

            return View(medicationType);
        }

        // GET: A1MedicationTypes/Create
        // This action is called when Create action is called fist time. 
        // This action is returing to the default view
        public IActionResult Create()
        {
            return View();
        }

        // POST: A1MedicationTypes/Create
        // This Post method recieves Medication Type object from the view. This object would have the current state of the view
        // New Medication Type entry would be created, reading the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicationTypeId,Name")] MedicationType medicationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicationType);
        }

        // GET: A1MedicationTypes/Edit/5
        // Default Edit action. Will be called first time the Edit action is called.
        // Parameter id is passed which is used to fetch the particular Medication Type record for edit operation.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationType = await _context.MedicationType.FindAsync(id);
            if (medicationType == null)
            {
                return NotFound();
            }
            return View(medicationType);
        }

        // POST: A1MedicationTypes/Edit/5
        // This Post method recieves Medication Type object from the view. This object would have the current state of the view
        // Existing Medication Type entry would be updated as per the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicationTypeId,Name")] MedicationType medicationType)
        {
            if (id != medicationType.MedicationTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationTypeExists(medicationType.MedicationTypeId))
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
            return View(medicationType);
        }

        // GET: A1MedicationTypes/Delete/5
        // Default action for the delete.Will be called first time the delete action is called.
        // Parameter id is passed which is used to fetch the particular Medication Type record for delete operation.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationType = await _context.MedicationType
                .FirstOrDefaultAsync(m => m.MedicationTypeId == id);
            if (medicationType == null)
            {
                return NotFound();
            }

            return View(medicationType);
        }

        // POST: A1MedicationTypes/Delete/5
        // Post Delete action. This is called as soon as user presses the Delete button on the View.
        // Medication Type corresponding to the id (passed as parameter) will be deleted from the database.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicationType = await _context.MedicationType.FindAsync(id);
            _context.MedicationType.Remove(medicationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // This function is used to check if particular country exists in the database or not
        private bool MedicationTypeExists(int id)
        {
            return _context.MedicationType.Any(e => e.MedicationTypeId == id);
        }
    }
}
