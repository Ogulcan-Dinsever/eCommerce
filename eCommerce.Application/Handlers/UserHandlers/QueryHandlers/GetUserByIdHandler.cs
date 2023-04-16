using AutoMapper;
using eCommerce.Application.Queries.UserQueries;
using eCommerce.Application.Repositories.Interfaces;
using eCommerce.Application.Responses;
using eCommerce.Application.Shared;
using eCommerce.Domain.eCommerceAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce.Application.Handlers.UserHandlers.QueryHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Response<GetUserResponse>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<GetUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
                return Response<GetUserResponse>.Fail("Bad Request", 409);

            GetUserResponse response = new GetUserResponse();

            var user = await _repository.Find(x => x.Id == request.Id);

            if (user != null)
            {
                response = _mapper.Map<GetUserResponse>(user);
                response.Token = GlobalFunctions.DecryptString(user.Password);
            }

            return Response<GetUserResponse>.Success(response, 200);
        }
    }
}
