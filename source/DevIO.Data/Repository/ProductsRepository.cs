using AppMVCBasic1.Models;
using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        public ProductsRepository(MyDbContext myDbContext) : base(myDbContext) { }
    

        public async Task<IEnumerable<Products>> GetProductsBySuppliers(Guid supplierId)
        {
           return await Get(p => p.Equals(supplierId));
        }

        public async Task<IEnumerable<Products>> GetProductsSupplier()
        {
            return await Db.Products.AsNoTracking().Include(f => f.Supplier).OrderBy(p => p.Name).ToArrayAsync();
        }

        public async Task<Products> GetProductsSupplier(Guid id)
        {
            return await Db.Products.AsNoTracking().Include(f => f.Supplier).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
