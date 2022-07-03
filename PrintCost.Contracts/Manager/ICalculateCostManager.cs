using PrintCost.Entities;
using PrintCost.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Contracts.Manager
{
    public interface ICalculateCostManager
    {
        public ServiceResponse CalculateCost(CostCalculate costCalculate);
    }
}
