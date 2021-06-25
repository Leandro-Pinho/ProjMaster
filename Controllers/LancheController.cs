using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMaster.Data;
using ProjMaster.Models;

namespace ProjMaster.Controllers
{
    public class LancheController : Controller
    {
        private readonly ProjMasterContext _context;

        public LancheController(ProjMasterContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> IndexMain(string LancheGenero, string searchString)
        {  Autenticacao.CheckLogin(this);
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Lanche orderby m.Genero select m.Genero;

            var movies = from m in _context.Lanche select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Nome.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(LancheGenero))
            {
                movies = movies.Where(x => x.Genero == LancheGenero);
            }

            var lancheGeneroVM = new LancheGeneroViewModel
            {
                Generos = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Lanches = await movies.ToListAsync()
            };

            return View(lancheGeneroVM);
        }
        
        [HttpPost]
        public string IndexMain(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            Autenticacao.CheckLogin(this);
            return View(await _context.Lanche.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Lanche
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Genero,Preco,ImagemUrl,ImagemThumbnailUrl")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lanche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lanche);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Lanche.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Genero,Preco,ImagemUrl,ImagemThumbnailUrl")] Lanche lanche)
        {
            if (id != lanche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lanche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(lanche.Id))
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
            return View(lanche);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Lanche
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Lanche.FindAsync(id);
            _context.Lanche.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Lanche.Any(e => e.Id == id);
        }
    }
}