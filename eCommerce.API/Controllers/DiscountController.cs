using eCommerce.Application.Commands.DiscountCommands;
using eCommerce.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/eCommerce/[controller]")]
    [ApiController]
    public class DiscountController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateDiscount")]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }
    }
}
