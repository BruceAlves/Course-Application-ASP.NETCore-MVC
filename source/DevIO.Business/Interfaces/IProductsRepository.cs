using AppMVCBasic1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProductsRepository : IRepository<Produts>
    {
        Task<IEnumerable<Produts>> GetProductsBySuppliers(Guid supplierId);
        Task<IEnumerable<Produts>> GetProductsSupplier();
        Task<Produts> GetProductsSupplier(Guid id);

    }
}
