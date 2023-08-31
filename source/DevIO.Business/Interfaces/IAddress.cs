using AppMVCBasic1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IAddress : IEquatable<IAddress>
    {
        Task<Address> GetAdddressBycSuppliers(Guid fornecedorId);
    }
}
