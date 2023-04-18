using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Responses
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetBrandResponse Brand { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public List<GetCategoryResponse> Categories { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
