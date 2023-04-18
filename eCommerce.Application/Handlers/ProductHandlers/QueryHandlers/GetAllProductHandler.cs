using AutoMapper;
using eCommerce.Application.Queries.ProductQueries;
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

namespace eCommerce.Application.Handlers.ProductHandlers.QueryHandlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, Response<List<GetProductResponse>>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IRepository<Product> repository, IRepository<Brand> brandRepository, IRepository<Category> categoryRepository, IRepository<Discount> discountRepository, IMapper mapper)
        {
            _repository = repository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            List<GetProductResponse> response = new List<GetProductResponse>();

            var getAllProduct = await _repository.GetAll(x => x.Status);

            var brandIds = getAllProduct.GroupBy(x => x.BrandId).Select(s => s.Key).ToList();
            var getAllBrand = await _brandRepository.GetAll(x => x.Status && brandIds.Contains(x.Id));

            var categories = await _categoryRepository.GetAll(x => x.Status);

            var getAllDiscount = await _discountRepository.GetAll(x => x.Status && x.StartDate>= DateTime.Now && x.EndDate <= DateTime.Now);

            foreach (var product in getAllProduct)
            {
                decimal discountRate = 0;

                var data = _mapper.Map<GetProductResponse>(product);

                var getBrand = getAllBrand.FirstOrDefault(x => x.Id == product.BrandId);
                data.Brand = _mapper.Map<GetBrandResponse>(getBrand);

                var getCategories = categories.Where(x => product.CategoryIds.Contains(x.Id)).ToList();
                data.Categories = _mapper.Map<List<GetCategoryResponse>>(getCategories);

                var getDiscounts = getAllDiscount.Where(x => product.CategoryIds.Contains(x.CategoryId)).ToList();

                if (getDiscounts != null)
                {
                    discountRate = getDiscounts.Max(x => x.DiscountRate) / 100;
                }

                var discount = product.Price * discountRate;
                data.DiscountedPrice = product.Price - discount;

                response.Add(data);
            }

            return Response<List<GetProductResponse>>.Success(response, 200);
        }
    }
}
