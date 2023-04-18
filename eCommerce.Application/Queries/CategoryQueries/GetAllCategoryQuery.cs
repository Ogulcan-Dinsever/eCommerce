using eCommerce.Application.Responses;
using eCommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Queries.CategoryQueries
{
    public class GetAllCategoryQuery : IRequest<Response<List<GetCategoryResponse>>>
    {
    }
}
