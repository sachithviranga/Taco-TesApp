using PrintCost.Contracts.Common;
using PrintCost.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Common.Mapper
{
    public class ServiceResponseMapper : IMapper<Object, ServiceResponse>
    {
        public ServiceResponse Map(object input)
        {
            return new ServiceResponse
            {
                ReturnObject = input,
                IsError = false
            };
        }
    }
}
