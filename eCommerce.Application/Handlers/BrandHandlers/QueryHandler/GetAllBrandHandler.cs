using AutoMapper;
using eCommerce.Application.Queries.BrandQueries;
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

namespace eCommerce.Application.Handlers.BrandHandlers.QueryHandler
{
    public class GetAllBrandHandler : IRequestHandler<GetAllBrandQuery, Response<List<GetBrandResponse>>>
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public GetAllBrandHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<GetBrandResponse>>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            List<GetBrandResponse> response = new List<GetBrandResponse>();

            var getAllBrands = await _repository.GetAll(x => x.Status);

            if (getAllBrands != null)
                response = _mapper.Map<List<GetBrandResponse>>(getAllBrands);

            return Response<List<GetBrandResponse>>.Success(response, 200);
        }
    }
}
