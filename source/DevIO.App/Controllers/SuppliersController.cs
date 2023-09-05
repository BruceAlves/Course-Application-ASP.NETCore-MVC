using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using AutoMapper;
using AppMVCBasic1.Models;

namespace DevIO.App.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;


        public SuppliersController(ISupplierRepository supplierrepository, IMapper mapper)
        {
            _supplierRepository = supplierrepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View( _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll()));
        }

    
        public async Task<IActionResult> Details(Guid id)
        {

            var supplierViewModel = await GetSupplierAddres(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Adding(supplier);

            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplier = await GetSupplierProductsAddres(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id) return NotFound();
            

            if (!ModelState.IsValid) return View(supplierViewModel);

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Update(supplier);

            return RedirectToAction("Index");           
           
        }


        public async Task<IActionResult> Delete(Guid id)
        {

            var supplierViewModel = await GetSupplierAddres(id);

            if (supplierViewModel == null) return NotFound();
     

            return View(supplierViewModel);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await  GetSupplierAddres(id);

            if (supplierViewModel == null) return NotFound();

            await _supplierRepository.Deleteing(id);
        
            return RedirectToAction("Index");
        }

        private async Task<SupplierViewModel> GetSupplierAddres(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierAddress(id));
        }

        private async Task<SupplierViewModel> GetSupplierProductsAddres(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierProductsAddress(id));
        }

    }
}
