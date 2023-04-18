using eCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.eCommerceAggregate
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }

        [Column("CategoryIds", TypeName = "integer[]")]
        public List<int> CategoryIds { get; set; }
    }
}
