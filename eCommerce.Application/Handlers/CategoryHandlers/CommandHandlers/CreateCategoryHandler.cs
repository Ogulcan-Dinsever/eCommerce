using AutoMapper;
using eCommerce.Application.Commands.CategoryCommands;
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

namespace eCommerce.Application.Handlers.CategoryHandlers.CommandHandlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Response<GetCategoryResponse>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<GetCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.CategoryName == "" || request.CategoryName == "string")
                return Response<GetCategoryResponse>.Fail("Category name cannot be empty or 'string'", 409);

            var isThere = await _repository.Any(x => x.Status && x.Name == request.CategoryName);
            if (isThere)
                return Response<GetCategoryResponse>.Fail("Category name already exist", 409);

            Category category = new Category
            {
                Name = request.CategoryName,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                Status = true
            };

            await _repository.Create(category);

            var response = _mapper.Map<GetCategoryResponse>(category);

            return Response<GetCategoryResponse>.Success(response, 201);
        }
    }
}
