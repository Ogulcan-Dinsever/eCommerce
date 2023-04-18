using eCommerce.Application.Responses;
using eCommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<Response<GetProductResponse>>
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        public List<string> CategoryNames { get; set; }
        public string CreatedBy { get; set; }
    }
}
