using eCommerce.Application.Responses;
using eCommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Commands.BrandCommands
{
    public class CreateBrandCommand : IRequest<Response<GetBrandResponse>>
    {
        public string BrandName { get; set; }
        public string CreatedBy { get; set; }
    }
}
