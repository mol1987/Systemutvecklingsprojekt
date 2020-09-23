using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloDarlingMVC3.Data;
using HelloDarlingMVC3.Models;
using System.Security.Claims;

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
            List<ProfileModel> CandidateList;
            if (searchType == "Alla")
            {
                CandidateList = await _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) || Search == null).ToListAsync();
        
            }
            else if (searchType == "Män")
            {
                CandidateList = await _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) && x.Gender == "man" || Search == null && x.Gender == "man").ToListAsync();
            
            }
            else if (searchType == "Kvinnor")
            {
                CandidateList = await _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) && x.Gender == "kvinna" || Search == null && x.Gender == "kvinna").ToListAsync();
             
            }
            else if (searchType == "Annat")
            {
                CandidateList = await _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) && x.Gender == "Annat" || Search == null && x.Gender == "Annat").ToListAsync();
           
            }
            else
            {
                CandidateList = await _context.ProfileModel.Where(x => x.FirstName.StartsWith(Search) || Search == null).ToListAsync();
          
            }


            var userID = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var profile = _context.ProfileModel.FirstOrDefault(x => x.Id.Equals(userID));
            profile.UserInterests = _context.Interests.FirstOrDefault(x => x.ProfileModelId.Equals(userID));

            CandidateList.Remove(profile);


            foreach (var item in CandidateList)
            {
                item.UserInterests = _context.Interests.FirstOrDefault(x => x.ProfileModelId.Equals(item.Id));
                if (item.UserInterests == null) item.UserInterests = new Interests();
                item.MatchingValue = MatchingValue(profile, item);
            }


            return View(CandidateList);
        }

        public int MatchingValue(ProfileModel profile1, ProfileModel profile2)
        {
            int sum = 0;
            int value = 0;

            if (profile1.UserInterests.Language == profile2.UserInterests.Language)
            {
                value += 1;
            }

            if (profile1.UserInterests.Movies == profile2.UserInterests.Movies)
            {
                value += 1;
            }

            if (profile1.UserInterests.Music == profile2.UserInterests.Music)
            {
                value += 1;
            }

            if (profile1.UserInterests.Cars == profile2.UserInterests.Cars)
            {
                value += 1;
            }

            if (profile1.UserInterests.Books == profile2.UserInterests.Books)
            {
                value += 1;
            }

            if (profile1.UserInterests.TVgame == profile2.UserInterests.TVgame)
            {
                value += 1;
            }

            if (profile1.UserInterests.Sports == profile2.UserInterests.Sports)
            {
                value += 1;
            }


            sum = (int)((value / 7.0) * 100.0);

            return sum;
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
