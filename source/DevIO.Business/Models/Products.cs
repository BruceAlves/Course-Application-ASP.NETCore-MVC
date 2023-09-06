using System;
using System.ComponentModel.DataAnnotations;

namespace AppMVCBasic1.Models
{
    public class Products : Entity
    {
        public Guid SupplierId { get; set; }
        
        public string Name { get; set; }
      
        public string Description { get; set; }
       
        public string Image { get; set; }

        public decimal Value { get; set; }

        public DateTime DateRegister { get; set; }
        public bool Active { get; set; }

        /*/EF Relation*/

        public Supplier Supplier { get; set; }

    }
}
