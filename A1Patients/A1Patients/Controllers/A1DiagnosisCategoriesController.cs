using A1Patients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace A1Patients.Controllers
{
    public class A1DiagnosisCategoriesController : Controller
    {
        private readonly PatientsContext _context;

        // Constructor of the Controller class
        public A1DiagnosisCategoriesController(PatientsContext context)
        {
            _context = context;
        }

        // GET: DiagnosisCategories
        // Gets the list of all Diagnosis Categories from database
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiagnosisCategory.ToListAsync());
        }

        // GET: DiagnosisCategories/Details/5
        // Gets the Diagnosis Category corresponding to the id passed as a parameter
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }

            return View(diagnosisCategory);
        }

        // GET: DiagnosisCategories/Create
        // This action is called when Create action is called fist time. 
        // This action is returing to the default view
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiagnosisCategories/Create
        // This Post method recieves Diagnosis Categories object from the view. This object would have the current state of the view
        // New Diagnosis Categories entry would be created, reading the values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DiagnosisCategory diagnosisCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnosisCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diagnosisCategory);
        }

        // GET: DiagnosisCategories/Edit/5
        // Default Edit action. Will be called first time the Edit action is called.
        // Parameter id is passed which is used to fetch the particular Diagnosis Categories record for edit operation.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategory.FindAsync(id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }
            return View(diagnosisCategory);
        }

        // POST: DiagnosisCategories/Edit/5
        // This Post method recieves Diagnosis Categories object from the view. This object would have the current state of the view
        // Existing Diagnosis Categories entry would be updated as per values from the parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DiagnosisCategory diagnosisCategory)
        {
            if (id != diagnosisCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnosisCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosisCategoryExists(diagnosisCategory.Id))
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
            return View(diagnosisCategory);
        }

        // GET: DiagnosisCategories/Delete/5
        // Default action for the delete.Will be called first time the delete action is called.
        // Parameter id is passed which is used to fetch the particular Diagnosis Categories record for delete operation.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }

            return View(diagnosisCategory);
        }

        // POST: DiagnosisCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // Post Delete action. This is called as soon as user presses the Delete button on the View.
        // Diagnosis Categories corresponding to the id (passed as parameter) will be deleted from the database.
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diagnosisCategory = await _context.DiagnosisCategory.FindAsync(id);
            _context.DiagnosisCategory.Remove(diagnosisCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // This function is used to check if particular Diagnosis Categories exists in the database or not
        private bool DiagnosisCategoryExists(int id)
        {
            return _context.DiagnosisCategory.Any(e => e.Id == id);
        }
    }
}
