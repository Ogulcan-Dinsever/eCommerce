using eCommerce.Application.Commands.DiscountCommands;
using eCommerce.Application.Repositories.Interfaces;
using eCommerce.Application.Shared;
using eCommerce.Domain.eCommerceAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce.Application.Handlers.DiscountHandlers.CommandHandlers
{
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, Response<bool>>
    {
        private readonly IRepository<Discount> _repository;
        private readonly IRepository<Category> _categoryRepository;

        public CreateDiscountHandler(IRepository<Discount> repository, IRepository<Category> categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<bool>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            if (request.DiscountRate == 100)
                return Response<bool>.Fail("Discount rate can not be %100", 409);

            var getCategory = await _categoryRepository.Find(x => x.Status && x.Name == request.CategoryName);

            if (getCategory == null)
                return Response<bool>.Fail("Category is not found", 409);

            var isThere = await _repository.Any(x => x.Status && (x.EndDate >= request.StartDate || x.StartDate <= request.EndDate));

            if (isThere)
                return Response<bool>.Fail("There is already a discount between these dates", 409);

            Discount discount = new Discount
            {
                Name = request.DiscountName,
                CategoryId = getCategory.Id,
                DiscountRate = request.DiscountRate,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                Status = true
            };

            await _repository.Create(discount);

            return Response<bool>.Success(true, 201);
        }
    }
}
