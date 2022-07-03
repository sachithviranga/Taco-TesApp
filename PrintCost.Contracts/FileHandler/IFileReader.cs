using PrintCost.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Contracts.FileHandler
{
    public interface IFileReader
    {
        List<PrintOutCount> GetPrintOutCounts(CostCalculate costCalculate);
    }
}
