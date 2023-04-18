using eCommerce.Application.Commands.CategoryCommands;
using eCommerce.Application.Queries.CategoryQueries;
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
    public class CategoryController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var response = await _mediator.Send(new GetAllCategoryQuery());

            return CreateActionResultInstance(response);
        }
    }
}
