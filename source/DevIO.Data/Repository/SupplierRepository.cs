using AppMVCBasic1.Models;
using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(  MyDbContext myDbContext) : base(myDbContext) { }
     
        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            return  await Db.Suppliers.AsNoTracking()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Equals(id));
        }

        public async Task<Supplier> GetSupplierProductsAddress(Guid id)
        {
            return await Db.Suppliers.AsNoTracking()
                .Include(C => C.Products)
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id ==  id);
        }
    }
}
