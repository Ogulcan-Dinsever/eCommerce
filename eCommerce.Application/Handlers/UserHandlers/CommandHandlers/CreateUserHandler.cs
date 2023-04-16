using AutoMapper;
using eCommerce.Application.Commands.UserCommands;
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

namespace eCommerce.Application.Handlers.UserHandlers.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Response<GetUserResponse>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<GetUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Name == "" || request.Name == "string" || request.SurName == "" || request.SurName == "string" || request.Password == "" || request.Password == "string")
                return Response<GetUserResponse>.Fail("Name, Surname or Password cannot be empty or 'string'", 409);

            if (!GlobalFunctions.EmailControll(request.Email))
                return Response<GetUserResponse>.Fail("Please enter a correct e mail", 409);

            var isThere = await _repository.Any(x => x.Status && x.Email == request.Email);

            if (isThere)
                return Response<GetUserResponse>.Fail("This email is already registered", 409);

            User user = new User
            {
                Email = request.Email,
                CreatedDate = DateTime.Now,
                Password = GlobalFunctions.EncryptString(request.Password),
                Role = request.Role,
                Name = request.Name,
                SurName = request.SurName,
            };

            var isSuccess = await _repository.Create(user) >= 1;
            if (!isSuccess)
                return Response<GetUserResponse>.Fail("Something wrong", 409);

            var response = _mapper.Map<GetUserResponse>(user);

            return Response<GetUserResponse>.Success(response, 201);
        }
    }
}
