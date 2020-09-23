using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloDarlingMVC3.Data;
using HelloDarlingMVC3.Models;

namespace HelloDarlingMVC3.Controllers
{
    public class FindMatchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FindMatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FindMatch
        public async Task<IActionResult> Index(string searchType, string Search)
        {
            if (searchType == "Alla")
            {
                var applicationDbContext = _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) || Search == null);
                return View(await applicationDbContext.ToListAsync());
            }
            else if (searchType == "Män")
            {
                var applicationDbContext = _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) && x.Gender == "man" || Search == null && x.Gender == "man");
                return View(await applicationDbContext.ToListAsync());
            }
            else if (searchType == "Kvinnor")
            {
                var applicationDbContext = _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) && x.Gender == "kvinna" || Search == null && x.Gender == "kvinna");
                return View(await applicationDbContext.ToListAsync());
            }
            else if (searchType == "Annat")
            {
                var applicationDbContext = _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) && x.Gender == "Annat" || Search == null && x.Gender == "Annat");
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) || Search == null);
                return View(await applicationDbContext.ToListAsync());
            }
        }

            // GET: FindMatch/Details/5
            public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileModel = await _context.ProfileModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileModel == null)
            {
                return NotFound();
            }

            return View(profileModel);
        }

        // GET: FindMatch/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FindMatch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityNO,FirstName,LastName,FileName,ImageName,UsersCategory,JoinDate,Place,Gender,Status,Bio")] ProfileModel profileModel)
        {
            if (ModelState.IsValid)
            {
                profileModel.Id = Guid.NewGuid();
                _context.Add(profileModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileModel);
        }

        // GET: FindMatch/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileModel = await _context.ProfileModel.FindAsync(id);
            if (profileModel == null)
            {
                return NotFound();
            }
            return View(profileModel);
        }

        // POST: FindMatch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,IdentityNO,FirstName,LastName,FileName,ImageName,UsersCategory,JoinDate,Place,Gender,Status,Bio")] ProfileModel profileModel)
        {
            if (id != profileModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileModelExists(profileModel.Id))
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
            return View(profileModel);
        }

        // GET: FindMatch/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileModel = await _context.ProfileModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileModel == null)
            {
                return NotFound();
            }

            return View(profileModel);
        }

        // POST: FindMatch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profileModel = await _context.ProfileModel.FindAsync(id);
            _context.ProfileModel.Remove(profileModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileModelExists(Guid id)
        {
            return _context.ProfileModel.Any(e => e.Id == id);
        }
    }
}
