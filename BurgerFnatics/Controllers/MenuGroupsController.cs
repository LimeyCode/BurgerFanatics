using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerFnatics.Data;
using BurgerFnatics.Models;

namespace BurgerFnatics.Controllers
{
    public class MenuGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MenuGroups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MenuGroup.Include(m => m.Menu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MenuGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGroup = await _context.MenuGroup
                .Include(m => m.Menu)
                .FirstOrDefaultAsync(m => m.MenuGroupID == id);
            if (menuGroup == null)
            {
                return NotFound();
            }

            return View(menuGroup);
        }

        // GET: MenuGroups/Create
        public IActionResult Create()
        {
            ViewData["MenuID"] = new SelectList(_context.Menu, "MenuName", "MenuName");
            return View();
        }

        // POST: MenuGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuGroupID,MenuID,MenuGroupName,MenuGroupDescription")] MenuGroup menuGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuID"] = new SelectList(_context.Menu, "MenuID", "MenuID", menuGroup.MenuID);
            return View(menuGroup);
        }

        // GET: MenuGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGroup = await _context.MenuGroup.FindAsync(id);
            if (menuGroup == null)
            {
                return NotFound();
            }
            ViewData["MenuID"] = new SelectList(_context.Menu, "MenuID", "MenuID", menuGroup.MenuID);
            return View(menuGroup);
        }

        // POST: MenuGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuGroupID,MenuID,MenuGroupName,MenuGroupDescription")] MenuGroup menuGroup)
        {
            if (id != menuGroup.MenuGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuGroupExists(menuGroup.MenuGroupID))
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
            ViewData["MenuID"] = new SelectList(_context.Menu, "MenuID", "MenuID", menuGroup.MenuID);
            return View(menuGroup);
        }

        // GET: MenuGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGroup = await _context.MenuGroup
                .Include(m => m.Menu)
                .FirstOrDefaultAsync(m => m.MenuGroupID == id);
            if (menuGroup == null)
            {
                return NotFound();
            }

            return View(menuGroup);
        }

        // POST: MenuGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuGroup = await _context.MenuGroup.FindAsync(id);
            _context.MenuGroup.Remove(menuGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuGroupExists(int id)
        {
            return _context.MenuGroup.Any(e => e.MenuGroupID == id);
        }
    }
}
