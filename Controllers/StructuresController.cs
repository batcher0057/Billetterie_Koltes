using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_Koltes.Models;

namespace CRM_Koltes.Controllers
{
    public class StructuresController : Controller
    {
        private readonly CrmKoltesDbContext _context;

        public StructuresController(CrmKoltesDbContext context)
        {
            _context = context;
        }

        // GET: Structures
        public async Task<IActionResult> Index()
        {
              return _context.Structures != null ? 
                          View(await _context.Structures.ToListAsync()) :
                          Problem("Entity set 'CrmKoltesDbContext.Structures'  is null.");
        }

        // GET: Structures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Structures == null)
            {
                return NotFound();
            }

            var structure = await _context.Structures
                .FirstOrDefaultAsync(m => m.IdStructure == id);
            if (structure == null)
            {
                return NotFound();
            }

            return View(structure);
        }

        // GET: Structures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Structures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStructure,RaisonCommerciale,RaisonSociale,Siret,StructDateEnregistrement,StructNumeroVoie,StructVoie,StructBis,StructCodePostal,StructVille,StructPays,StructCategorie,StructActivitePrincipale")] Structure structure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(structure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _context.Add(structure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(structure);
        }

        // GET: Structures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Structures == null)
            {
                return NotFound();
            }

            var structure = await _context.Structures.FindAsync(id);
            if (structure == null)
            {
                return NotFound();
            }
            return View(structure);
        }

        // POST: Structures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStructure,RaisonCommerciale,RaisonSociale,Siret,StructDateEnregistrement,StructNumeroVoie,StructVoie,StructBis,StructCodePostal,StructVille,StructPays,StructCategorie,StructActivitePrincipale")] Structure structure)
        {
            if (id != structure.IdStructure)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(structure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StructureExists(structure.IdStructure))
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
            return View(structure);
        }

        // GET: Structures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Structures == null)
            {
                return NotFound();
            }

            var structure = await _context.Structures
                .FirstOrDefaultAsync(m => m.IdStructure == id);
            if (structure == null)
            {
                return NotFound();
            }

            return View(structure);
        }

        // POST: Structures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Structures == null)
            {
                return Problem("Entity set 'CrmKoltesDbContext.Structures'  is null.");
            }
            var structure = await _context.Structures.FindAsync(id);
            if (structure != null)
            {
                _context.Structures.Remove(structure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StructureExists(int id)
        {
          return (_context.Structures?.Any(e => e.IdStructure == id)).GetValueOrDefault();
        }
    }
}
