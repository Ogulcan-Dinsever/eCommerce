using eCommerce.Application.Responses;
using eCommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<Response<GetCategoryResponse>>
    {
        public string CategoryName { get; set; }
        public string CreatedBy { get; set; }
    }
}
