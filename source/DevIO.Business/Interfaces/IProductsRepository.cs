using AppMVCBasic1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProductsRepository : IRepository<Products>
    {
        Task<IEnumerable<Products>> GetProductsBySuppliers(Guid supplierId);
        Task<IEnumerable<Products>> GetProductsSupplier();
        Task<Products> GetProductsSupplier(Guid id);

    }
}
