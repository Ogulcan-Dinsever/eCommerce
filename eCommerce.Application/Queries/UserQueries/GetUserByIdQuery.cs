using eCommerce.Application.Responses;
using eCommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<Response<GetUserResponse>>
    {
        public int Id { get; set; }
    }
}
