using AutoMapper;
using eCommerce.Application.Queries.CategoryQueries;
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

namespace eCommerce.Application.Handlers.CategoryHandlers.QueryHandlers
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, Response<List<GetCategoryResponse>>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetAllCategoryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<GetCategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var getAllCategory = await _repository.GetAll(x => x.Status);

            List<GetCategoryResponse> response = new List<GetCategoryResponse>();

            if (getAllCategory != null)
                response = _mapper.Map<List<GetCategoryResponse>>(getAllCategory);

            return Response<List<GetCategoryResponse>>.Success(response, 200);
        }
    }
}
