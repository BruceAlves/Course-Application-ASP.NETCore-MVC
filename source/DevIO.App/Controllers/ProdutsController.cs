using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevIO.App.Data;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using AutoMapper;

namespace DevIO.App.Controllers
{
    public class ProdutsController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProdutsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;

        }


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProdutsViewModel.Include(p => p.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtsViewModel = await _context.ProdutsViewModel
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtsViewModel == null)
            {
                return NotFound();
            }

            return View(produtsViewModel);
        }


        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_context.Set<SupplierViewModel>(), "Id", "Document");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SupplierId,Name,Description,Image,Value,Active")] ProdutsViewModel produtsViewModel)
        {
            if (ModelState.IsValid)
            {
                produtsViewModel.Id = Guid.NewGuid();
                _context.Add(produtsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Set<SupplierViewModel>(), "Id", "Document", produtsViewModel.SupplierId);
            return View(produtsViewModel);
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtsViewModel = await _context.ProdutsViewModel.FindAsync(id);
            if (produtsViewModel == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.Set<SupplierViewModel>(), "Id", "Document", produtsViewModel.SupplierId);
            return View(produtsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SupplierId,Name,Description,Image,Value,Active")] ProdutsViewModel produtsViewModel)
        {
            if (id != produtsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtsViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutsViewModelExists(produtsViewModel.Id))
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
            ViewData["SupplierId"] = new SelectList(_context.Set<SupplierViewModel>(), "Id", "Document", produtsViewModel.SupplierId);
            return View(produtsViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtsViewModel = await _context.ProdutsViewModel
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtsViewModel == null)
            {
                return NotFound();
            }

            return View(produtsViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtsViewModel = await _context.ProdutsViewModel.FindAsync(id);
            _context.ProdutsViewModel.Remove(produtsViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

           
    }
}
