using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WeaponManager.Data;
using WeaponManager.Models;
using X.PagedList;

namespace WeaponManager.Controllers
{
    public class ColdWeaponsController : Controller
    {
        private readonly WeaponManagerDbContext _context;

        public ColdWeaponsController(WeaponManagerDbContext context)
        {
            _context = context;
        }

        // GET: ColdWeapons
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchName, int? price, int? page)
        {
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.WeightSortParm = sortOrder == "Weight" ? "weight_desc" : "Weight";
            ViewBag.BladeLengthSortParm = sortOrder == "BladeLength" ? "blade_desc" : "BladeLength";
            ViewBag.TypeSortParm = sortOrder == "Type" ? "type_desc" : "Type";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            var weapons = await _context.ColdWeapons.ToListAsync();
            // display the newest record first
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

        // GET: ColdWeapons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldWeapon = await _context.ColdWeapons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coldWeapon == null)
            {
                return NotFound();
            }

            return View(coldWeapon);
        }

        // GET: ColdWeapons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColdWeapons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BladeLength,Weight,Type,Id,Name,Price")] ColdWeapon coldWeapon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coldWeapon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coldWeapon);
        }

        // GET: ColdWeapons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldWeapon = await _context.ColdWeapons.FindAsync(id);
            if (coldWeapon == null)
            {
                return NotFound();
            }
            return View(coldWeapon);
        }

        // POST: ColdWeapons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BladeLength,Weight,Type,Id,Name,Price")] ColdWeapon coldWeapon)
        {
            if (id != coldWeapon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coldWeapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColdWeaponExists(coldWeapon.Id))
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
            return View(coldWeapon);
        }

        // GET: ColdWeapons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldWeapon = await _context.ColdWeapons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coldWeapon == null)
            {
                return NotFound();
            }

            return View(coldWeapon);
        }

        // POST: ColdWeapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coldWeapon = await _context.ColdWeapons.FindAsync(id);
            _context.ColdWeapons.Remove(coldWeapon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColdWeaponExists(int id)
        {
            return _context.ColdWeapons.Any(e => e.Id == id);
        }
    }
}
