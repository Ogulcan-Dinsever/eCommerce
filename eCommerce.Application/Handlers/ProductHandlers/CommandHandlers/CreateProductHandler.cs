using AutoMapper;
using eCommerce.Application.Commands.ProductCommands;
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

namespace eCommerce.Application.Handlers.ProductHandlers.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Response<GetProductResponse>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IRepository<Product> repository, IRepository<Brand> brandRepository, IRepository<Category> categoryRepository, IMapper mapper)
        {
            _repository = repository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductName == "" || request.ProductName == "string")
                return Response<GetProductResponse>.Fail("Product name cannot be empty or 'string'", 409);

            if (request.Price == 0)
                return Response<GetProductResponse>.Fail("Product price cannot be 0", 409);

            var getBrand = await _brandRepository.Find(x => x.Status && request.ProductName == x.Name);
            if (getBrand == null)
                return Response<GetProductResponse>.Fail("This brand is not found", 409);

            var getCategories = await _categoryRepository.GetAll(x => x.Status && request.CategoryNames.Contains(x.Name));

            if (getCategories.Count != request.CategoryNames.Count)
            {
                foreach (var categoryName in request.CategoryNames)
                {
                    var isThere = getCategories.Any(x => x.Name == categoryName);
                    if (isThere)
                        continue;

                    return Response<GetProductResponse>.Fail($"{categoryName} is not found", 409);
                }
            }

            var getCategoryIds = getCategories.GroupBy(x => x.Id).Select(s => s.Key).ToList();

            Product product = new Product
            {
                Name = request.BrandName,
                BrandId = getBrand.Id,
                Price = request.Price,
                CategoryIds = getCategoryIds,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                Status = true
            };

            var isSuccess = await _repository.Create(product) >= 1;
            if (!isSuccess)
                return Response<GetProductResponse>.Fail("Something wrong", 409);

            GetProductResponse response = new GetProductResponse();

            response = _mapper.Map<GetProductResponse>(product);

            response.Brand = _mapper.Map<GetBrandResponse>(getBrand);
            response.Categories = _mapper.Map<List<GetCategoryResponse>>(getCategories);

            return Response<GetProductResponse>.Success(response, 201);
        }
    }
}
