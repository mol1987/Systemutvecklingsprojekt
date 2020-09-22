using HelloDarlingMVC3.Data;
using HelloDarlingMVC3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HelloDarlingMVC3.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Match.Include(m => m.Profile1).Include(m => m.Profile2);

            var personId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var matches = _context.Match.Where(www => www.Profile2Id == personId).ToList();
            
            List<ProfileModel> potentialMatches = new List<ProfileModel>();
            List<ProfileModel> allMatches = new List<ProfileModel>();

            foreach (var item in matches)
            {
                if (item.Status == 1)
                {
                    potentialMatches.Add(_context.ProfileModel.FirstOrDefault(x => x.Id.Equals(item.Profile1Id)));
                }
                else if (item.Status == 2)
                {
                    allMatches.Add(_context.ProfileModel.FirstOrDefault(x => x.Id.Equals(item.Profile1Id)));
                }
            }

            return View(matches);
        }

        public async Task<IActionResult> CreateMatch(Guid? id)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            if (id == null)
            {
                return NotFound();
            }

            Match match = await _context.Match
                .Include(m => m.Profile1)
                .Include(m => m.Profile2)
                .FirstOrDefaultAsync(m => m.Profile1Id == userId && (m.Profile2Id == id));
            Match matched = await _context.Match
                .Include(m => m.Profile1)
                .Include(m => m.Profile2)
                .FirstOrDefaultAsync(m => (m.Profile2Id == userId) && (m.Profile1Id == id));
            if (match == null && matched == null)
            {
                match = new Match();
                match.MatchDate = DateTime.Now;
                match.Profile1Id = userId;
                match.Profile2Id = Guid.Parse(id.ToString());
                match.Status = 1;
                _context.Match.Add(match);
            } else if (match == null && matched != null)
            {
                match = new Match();
                match.MatchDate = DateTime.Now;
                match.Profile1Id = userId;
                match.Profile2Id = Guid.Parse(id.ToString());
                match.Status = 2;
                matched.Status = 2;
                _context.Match.Add(match);
                _context.Update(matched);
            }  else
            {
                return View();
            }  
            await _context.SaveChangesAsync();

            return View();
        }


        // GET: Matches/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Profile1)
                .Include(m => m.Profile2)
                .FirstOrDefaultAsync(m => m.Profile1Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["Profile1Id"] = new SelectList(_context.ProfileModel, "Id", "Id");
            ViewData["Profile2Id"] = new SelectList(_context.ProfileModel, "Id", "Id");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Profile1Id,Profile2Id,MatchDate,Favorite,Status")] Match match)
        {
            if (ModelState.IsValid)
            {
                match.Profile1Id = Guid.NewGuid();
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Profile1Id"] = new SelectList(_context.ProfileModel, "Id", "Id", match.Profile1Id);
            ViewData["Profile2Id"] = new SelectList(_context.ProfileModel, "Id", "Id", match.Profile2Id);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["Profile1Id"] = new SelectList(_context.ProfileModel, "Id", "Id", match.Profile1Id);
            ViewData["Profile2Id"] = new SelectList(_context.ProfileModel, "Id", "Id", match.Profile2Id);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Profile1Id,Profile2Id,MatchDate,Favorite,Status")] Match match)
        {
            if (id != match.Profile1Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Profile1Id))
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
            ViewData["Profile1Id"] = new SelectList(_context.ProfileModel, "Id", "Id", match.Profile1Id);
            ViewData["Profile2Id"] = new SelectList(_context.ProfileModel, "Id", "Id", match.Profile2Id);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Profile1)
                .Include(m => m.Profile2)
                .FirstOrDefaultAsync(m => m.Profile1Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var match = await _context.Match.FindAsync(id);
            _context.Match.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(Guid id)
        {
            return _context.Match.Any(e => e.Profile1Id == id);
        }
    }
}
