using AutoMapper;
using eCommerce.Application.Commands.BrandCommands;
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

namespace eCommerce.Application.Handlers.BrandHandlers.CommandHandlers
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, Response<GetBrandResponse>>
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public CreateBrandHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<GetBrandResponse>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            if (request.BrandName == "" || request.BrandName == "string")
                return Response<GetBrandResponse>.Fail("Brand name cannot be empty or 'string'", 409);

            var isThere = await _repository.Any(x => x.Status && x.Name == request.BrandName);
            if (isThere)
                return Response<GetBrandResponse>.Fail("Brand name already exist", 409);

            Brand brand = new Brand
            {
                Name = request.BrandName,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                Status = true
            };

            var isSuccess = await _repository.Create(brand) >= 1;
            if (!isSuccess)
                return Response<GetBrandResponse>.Fail("Something wrong", 409);

            var response = _mapper.Map<GetBrandResponse>(brand);

            return Response<GetBrandResponse>.Success(response, 201);
        }
    }
}
