using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WeaponManager.Data;
using WeaponManager.Models;
using X.PagedList;

namespace WeaponManager.Controllers
{
    public class PistolsController : Controller
    {
        private readonly WeaponManagerDbContext _context;

        public PistolsController(WeaponManagerDbContext context)
        {
            _context = context;
        }

        // GET: Pistols
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchName, int? price, int? page)
        {
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.WeightSortParm = sortOrder == "Weight" ? "weight_desc" : "Weight";
            ViewBag.MuzzleSortParm = sortOrder == "MuzzleVelocity" ? "muzzle_desc" : "MuzzleVelocity";
            ViewBag.MagazineSortParm = sortOrder == "MagazineCapacity" ? "magazine_desc" : "MagazineCapacity";
            ViewBag.TypeSortParm = sortOrder == "PistolType" ? "type_desc" : "PistolType";
            ViewBag.RangeSortParm = sortOrder == "PistolRange" ? "range_desc" : "PistolRange";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            var weapons = await _context.Pistols.ToListAsync();
            // display newest record first
            weapons.Reverse();

            // go to the first page if there is a filter
            if (searchName != null || price != null)
            {
                page = 1;
            }
            else
            {
                searchName = currentFilter;
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = searchName;

            weapons = ControllerUtils.FilterAndOrder(weapons, sortOrder, searchName, price);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(weapons.ToPagedList(pageNumber, pageSize));
        }

        // GET: Pistols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pistol = await _context.Pistols
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pistol == null)
            {
                return NotFound();
            }

            return View(pistol);
        }

        // GET: Pistols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pistols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Weight,PistolRange,PistolType,MuzzleVelocity,MagazineCapacity,Id,Name,Price")] Pistol pistol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pistol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pistol);
        }

        // GET: Pistols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pistol = await _context.Pistols.FindAsync(id);
            if (pistol == null)
            {
                return NotFound();
            }
            return View(pistol);
        }

        // POST: Pistols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Weight,PistolRange,PistolType,MuzzleVelocity,MagazineCapacity,Id,Name,Price")] Pistol pistol)
        {
            if (id != pistol.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pistol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PistolExists(pistol.Id))
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
            return View(pistol);
        }

        // GET: Pistols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pistol = await _context.Pistols
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pistol == null)
            {
                return NotFound();
            }

            return View(pistol);
        }

        // POST: Pistols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pistol = await _context.Pistols.FindAsync(id);
            _context.Pistols.Remove(pistol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PistolExists(int id)
        {
            return _context.Pistols.Any(e => e.Id == id);
        }
    }
}
