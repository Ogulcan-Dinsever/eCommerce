using eCommerce.Application.Commands.BrandCommands;
using eCommerce.Application.Queries.BrandQueries;
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
    public class BrandController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetAllBrand")]
        public async Task<IActionResult> GetAllBrand()
        {
            var response = await _mediator.Send(new GetAllBrandQuery());

            return CreateActionResultInstance(response);
        }
    }
}
