using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Mapping
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<eCommerceAutoMapperProfile>();
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;
    }
}
