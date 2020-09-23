using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloDarlingMVC3.Data;
using HelloDarlingMVC3.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace HelloDarlingMVC3.Controllers
{
    [Authorize]
    public class ProfileModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProfileModelsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: ProfileModels
        public async Task<IActionResult> Profiles(Guid Id)
        {

            var profile = _context.ProfileModel.FirstOrDefault(x => x.Id.Equals(Id));
            //var username = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            //var profileUsername = _context.ProfileModel.FirstOrDefault(x => x.Username.Equals(username));

            profile.UserAppearance = _context.Appearance.FirstOrDefault(x => x.ProfileModelId.Equals(Id));

            profile.UserInterests = _context.Interests.FirstOrDefault(x => x.ProfileModelId.Equals(Id));

            profile.UserPreference = _context.Preference.FirstOrDefault(x => x.ProfileModelId.Equals(Id));

            

            return View(profile);
        }

            // GET: ProfileModels
        public async Task<IActionResult> Index()
        {
            var userID= Guid.Parse(User.Claims.FirstOrDefault(x => x.Type==ClaimTypes.NameIdentifier).Value);
            var profile = _context.ProfileModel.FirstOrDefault(x => x.Id.Equals(userID));


            if (profile ==null)
            {
                profile = new ProfileModel();
                profile.Id = userID;
                _context.Add(profile);
                await _context.SaveChangesAsync();
            }
            
            profile.UserAppearance = _context.Appearance.FirstOrDefault(x => x.ProfileModelId.Equals(userID));

            if (profile.UserAppearance == null)
            {
                profile.UserAppearance = new Appearance();
                profile.UserAppearance.ProfileModelId = profile.Id;
                _context.Add(profile.UserAppearance);
                await _context.SaveChangesAsync();
            }

            profile.UserInterests = _context.Interests.FirstOrDefault(x => x.ProfileModelId.Equals(userID));

            if (profile.UserInterests == null)
            {
                profile.UserInterests = new Interests();
                profile.UserInterests.ProfileModelId = profile.Id;
                _context.Add(profile.UserInterests);
                await _context.SaveChangesAsync();
            }

            profile.UserPreference = _context.Preference.FirstOrDefault(x => x.ProfileModelId.Equals(userID));

            if (profile.UserPreference == null)
            {
                profile.UserPreference = new Preference();
                profile.UserPreference.ProfileModelId = profile.Id;
                _context.Add(profile.UserPreference);
                await _context.SaveChangesAsync();
            }

            return View(profile);
        }

        // GET: ProfileModels/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileModel = await _context.ProfileModel
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (profileModel == null)
            {
                return NotFound();
            }

            return View(profileModel);
        }

        // GET: ProfileModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfileModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfileModel profileModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileModel);
        }

        // GET: ProfileModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: ProfileModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileModel profileModel)
        {
            
            profileModel.Id = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            //var extraProfile = (await _context.ProfileModel.FirstOrDefaultAsync(m => m.Id.Equals(profileModel.Id)));
            profileModel.UserAppearance.ProfileModelId = profileModel.Id;
            profileModel.UserInterests.ProfileModelId = profileModel.Id;
            //profileModel.UserPreference.ProfileModelId = profileModel.Id;



            if (ModelState.IsValid)
            { 
                if (profileModel.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(profileModel.ImageFile.FileName);
                    string extension = Path.GetExtension(profileModel.ImageFile.FileName);
                    profileModel.ImageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Image", profileModel.ImageName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await profileModel.ImageFile.CopyToAsync(fileStream);
                    }
                    //profileModel.ImageFile = null;
                }
                //profileModel.ImageName = extraProfile.ImageName;
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
                //return View("Index");

                return RedirectToAction("Index");

            }
            return View(profileModel);
        }

        // GET: ProfileModels/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileModel = await _context.ProfileModel
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (profileModel == null)
            {
                return NotFound();
            }

            return View(profileModel);
        }

        // POST: ProfileModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profileModel = await _context.ProfileModel.FindAsync(id);
            _context.ProfileModel.Remove(profileModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileModelExists(Guid id)
        {
            return _context.ProfileModel.Any(e => e.Id.Equals(id));
        }
    }
}
