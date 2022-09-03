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
    public class IndividusController : Controller
    {
        private readonly CrmKoltesDbContext _context;

        public IndividusController(CrmKoltesDbContext context)
        {
            _context = context;
        }

        // GET: Individus
        public async Task<IActionResult> Index()
        {
              return _context.Individus != null ? 
                          View(await _context.Individus.ToListAsync()) :
                          Problem("Entity set 'CrmKoltesDbContext.Individus'  is null.");
        }

        public async Task<bool> IfEmailExist(string email)
        {
            var personne = await _context.Individus
                .FirstOrDefaultAsync(m => m.Courriel == email);
            if (personne != null)
            {
                return true;
            }
            return false;
        }

        // GET: Individus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Individus == null)
            {
                return NotFound();
            }

            var individu = await _context.Individus
                .FirstOrDefaultAsync(m => m.IdIndividu == id);
            if (individu == null)
            {
                return NotFound();
            }

            return View(individu);
        }

        // GET: Individus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Individus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIndividu,Courriel,MotDePasse,Civilite,Nom,Prenom,DateNaissance,TelMobile,Pseudo,Categorie,IsAdmin,IsCoworker")] Individu individu)
        {
            if (await IfEmailExist(individu.Courriel))
            {
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                _context.Add(individu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _context.Add(individu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(individu);
        }

        // GET: Individus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Individus == null)
            {
                return NotFound();
            }

            var individu = await _context.Individus.FindAsync(id);
            if (individu == null)
            {
                return NotFound();
            }
            return View(individu);
        }

        // POST: Individus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIndividu,Courriel,MotDePasse,Civilite,Nom,Prenom,DateNaissance,TelMobile,Pseudo,Categorie,IsAdmin,IsCoworker")] Individu individu)
        {
            if (id != individu.IdIndividu)
            {
                return NotFound();
            }

            //ajouter l'heure à la date
            if (individu.DateNaissance.ToString().Length < 11)
            {
                string s = individu.DateNaissance.ToString() + " 12:00:00";
                individu.DateNaissance = DateTime.Parse(s);
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividuExists(individu.IdIndividu))
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
            else
            {
                try
                {
                    _context.Update(individu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividuExists(individu.IdIndividu))
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
            //return View(individu);
        }

        // GET: Individus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Individus == null)
            {
                return NotFound();
            }

            var individu = await _context.Individus
                .FirstOrDefaultAsync(m => m.IdIndividu == id);
            if (individu == null)
            {
                return NotFound();
            }

            return View(individu);
        }

        // POST: Individus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Individus == null)
            {
                return Problem("Entity set 'CrmKoltesDbContext.Individus'  is null.");
            }
            var individu = await _context.Individus.FindAsync(id);
            if (individu != null)
            {
                _context.Individus.Remove(individu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndividuExists(int id)
        {
          return (_context.Individus?.Any(e => e.IdIndividu == id)).GetValueOrDefault();
        }
    }
}
