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
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(MyDbContext myDbContext) : base(myDbContext) { }
    
        public async Task<Address> GetAdddressBycSuppliers(Guid fornecedorId)
        {
            return await Db.Addresses.AsNoTracking().FirstOrDefaultAsync(f => f.SupplierId == fornecedorId);
        }
    }
}
