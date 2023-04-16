using eCommerce.Application.Responses;
using eCommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Commands.UserCommands
{
    public class LoginCommand : IRequest<Response<GetUserResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
