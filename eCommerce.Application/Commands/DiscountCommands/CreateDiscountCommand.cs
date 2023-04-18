using eCommerce.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Commands.DiscountCommands
{
    public class CreateDiscountCommand : IRequest<Response<bool>>
    {
        public string DiscountName { get; set; }
        public decimal DiscountRate { get; set; }
        public string CategoryName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
