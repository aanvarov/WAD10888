using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WAD.WebApp._10888.DAL;
using WAD.WebApp._10888.DAL.DBO;
using WAD.WebApp._10888.DAL.Repos;

namespace WAD.WebApp._10888.Controllers
{
    public class SteaksController : Controller
    {
        //private readonly SteakDbContext _context;
        private readonly IRepos<Steak> _steakRepo;
        private readonly IRepos<Category> _categoryRepo;

        public SteaksController(IRepos<Steak> steakRepo, IRepos<Category> categoryRepo)
        {
            _steakRepo = steakRepo;
            _categoryRepo = categoryRepo;
        }

        // GET: Steaks
        public async Task<IActionResult> Index()
        {
            return View(await _steakRepo.GetAllAsync());
        }

        // GET: Steaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steak = await _steakRepo.GetByIdAsync(id.Value);
            if (steak == null)
            {
                return NotFound();
            }

            return View(steak);
        }

        // GET: Steaks/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            //Enum.GetValues(typeof(SteakSize)).Cast<SteakSize>().ToList();
            ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAllAsync(), "Id", "CategoryName");
            ViewData["Size"] = new SelectList(Enum.GetValues(typeof(SteakSize)).Cast<SteakSize>().ToList());
            return View();
        }

        // POST: Steaks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,CategoryId,Size,SteakPhoto")] Steak steak)
        {
            if (ModelState.IsValid)
            {
                byte[] photoBytes = null;
                if (steak.SteakPhoto != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        steak.SteakPhoto.CopyTo(memory);
                        photoBytes = memory.ToArray();
                    }
                }
                steak.BinaryPhoto = photoBytes;
                await _steakRepo.CreateAsync(steak);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAllAsync(), "Id", "CategoryName", steak.CategoryId);
            //ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", steak.CategoryId);
            return View(steak);
        }

        // GET: Steaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steak = await _steakRepo.GetByIdAsync(id.Value);
            if (steak == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAllAsync(), "Id", "CategoryName", steak.CategoryId);
            ViewData["Size"] = new SelectList(Enum.GetValues(typeof(SteakSize)).Cast<SteakSize>().ToList());
            //ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", steak.CategoryId);
            return View(steak);
        }

        // POST: Steaks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,CategoryId,Size,BinaryPhoto,SteakPhoto")] Steak steak)
        {
            if (id != steak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    byte[] photoBytes = null;
                    if (steak.SteakPhoto != null)
                    {
                        using (var memory = new MemoryStream())
                        {
                            steak.SteakPhoto.CopyTo(memory);
                            photoBytes = memory.ToArray();
                        }
                    }else
                    {
                        photoBytes = steak.BinaryPhoto;
                    }
                    steak.BinaryPhoto = photoBytes;
                    await _steakRepo.UpdateAsync(steak);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_steakRepo.Exists(steak.Id))
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
            ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAllAsync(), "Id", "CategoryName", steak.CategoryId);
            //ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", steak.CategoryId);
            return View(steak);
        }

        // GET: Steaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steak = await _steakRepo.GetByIdAsync(id.Value);
            if (steak == null)
            {
                return NotFound();
            }

            return View(steak);
        }

        // POST: Steaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _steakRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ShowImage(int? id)
        {
            if (id.HasValue)
            {
                var steak = await _steakRepo.GetByIdAsync(id.Value);
                if (steak?.BinaryPhoto != null)
                {
                    return File(
                        steak.BinaryPhoto,
                        "image/jpeg",
                        $"employee_{id}.jpg");
                }
            }

            return NotFound();
        }
    }
}
