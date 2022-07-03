using PrintCost.Contracts.Common;
using PrintCost.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Common.Mapper
{
    public class ServiceErrorMapper : IMapper<Message, ServiceResponse>
    {
        public ServiceResponse Map(Message input) => new ServiceResponse
        {
            IsError = true,
            Message = input
        };
    }
}
