using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WeaponManager.Data;
using WeaponManager.Models;
using X.PagedList;

namespace WeaponManager.Controllers
{
    public class RiflesController : Controller
    {
        private readonly WeaponManagerDbContext _context;

        public RiflesController(WeaponManagerDbContext context)
        {
            _context = context;
        }

        // GET: Rifles
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchName, int? price, int? page)
        {
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.MuzzleSortParm = sortOrder == "MuzzleVelocity" ? "muzzle_desc" : "MuzzleVelocity";
            ViewBag.MagazineSortParm = sortOrder == "MagazineCapacity" ? "magazine_desc" : "MagazineCapacity";
            ViewBag.CaliberSortParm = sortOrder == "Caliber" ? "caliber_desc" : "Caliber";
            ViewBag.TypeSortParm = sortOrder == "RifleType" ? "type_desc" : "RifleType";
            ViewBag.RangeSortParm = sortOrder == "RifleLength" ? "length_desc" : "RifleLength";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "price";

            var weapons = await _context.Rifles.ToListAsync();
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

        // GET: Rifles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rifle = await _context.Rifles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rifle == null)
            {
                return NotFound();
            }

            return View(rifle);
        }

        // GET: Rifles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rifles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Caliber,RifleLength,RifleType,MuzzleVelocity,MagazineCapacity,Id,Name,Price")] Rifle rifle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rifle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rifle);
        }

        // GET: Rifles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rifle = await _context.Rifles.FindAsync(id);
            if (rifle == null)
            {
                return NotFound();
            }
            return View(rifle);
        }

        // POST: Rifles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Caliber,RifleLength,RifleType,MuzzleVelocity,MagazineCapacity,Id,Name,Price")] Rifle rifle)
        {
            if (id != rifle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rifle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RifleExists(rifle.Id))
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
            return View(rifle);
        }

        // GET: Rifles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rifle = await _context.Rifles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rifle == null)
            {
                return NotFound();
            }

            return View(rifle);
        }

        // POST: Rifles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rifle = await _context.Rifles.FindAsync(id);
            _context.Rifles.Remove(rifle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RifleExists(int id)
        {
            return _context.Rifles.Any(e => e.Id == id);
        }
    }
}
