using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Entities.Common
{
    public class ServiceResponse
    {
        public Object ReturnObject { get; set; }

        public bool IsError { get; set; }

        public Message Message { get; set; }
    }
}
