using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppMVCBasic1.Models
{
    public class Supplier : Entity
    {
        
        public string Name { get; set; }
        public string Document { get; set; }
        [DisplayName("Tipo")]
        public TypeSupplier TypeSupplier { get; set; }
        public Address Address { get; set; }

        [DisplayName("Ativo?")]
        public bool Active { get; set; }

        /*EF Relatrions*/

        public IEnumerable<Products> Products { get; set; }
    }


}