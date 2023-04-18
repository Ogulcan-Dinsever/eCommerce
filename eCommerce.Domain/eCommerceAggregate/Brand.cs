using eCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.eCommerceAggregate
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
    }
}
