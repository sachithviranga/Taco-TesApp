using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Entities
{
    public class  CostCalculate
    {
        public bool IsDoubleSide { get; set; }

        public IFormFile File { get; set; }
    }
}
