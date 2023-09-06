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
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public ProductsController(
        IProductsRepository productsRepository,
        IMapper mapper,
        ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductsViewModel>>(await _productsRepository.GetProductsSupplier()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var produtsViewModel = await GetProduts(id);

            if (produtsViewModel == null)
            {
                return NotFound();
            }

            return View(produtsViewModel);
        }


        public async Task<IActionResult> Create()
        {
            var produtsViewModel = await PopularSuppliers(new ProductsViewModel());
            return View(produtsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductsViewModel produtsViewModel)
        {
            produtsViewModel = await PopularSuppliers(produtsViewModel);

            if (!ModelState.IsValid) return View(produtsViewModel);

            await _productsRepository.Adding(_mapper.Map<Products>(produtsViewModel));

            return View(produtsViewModel);

        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var produtsViewModel = await GetProduts(id);

            if (produtsViewModel == null)
            {
                return NotFound();
            }
          
            return View(produtsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductsViewModel produtsViewModel)
        {
            if (id != produtsViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(produtsViewModel);


            await _productsRepository.Update(_mapper.Map<Products>(produtsViewModel));  

            return RedirectToAction("Index");                 
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await GetProduts(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await GetProduts(id);

            if (product == null)
            {
                return NotFound();
            }
            await _productsRepository.Deleteing(id);

            return RedirectToAction("Index");
        }

        private async Task<ProductsViewModel> GetProduts(Guid id)
        {
            var produts = _mapper.Map<ProductsViewModel>(await _productsRepository.GetProductsSupplier(id));

            produts.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());

            return produts;
        }
        private async Task<ProductsViewModel> PopularSuppliers(ProductsViewModel produts)
        {

            produts.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());

            return produts;
        }
    }
}
