using eCommerce.Domain.eCommerceAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence
{
    public class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
    }
}
