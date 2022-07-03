using PrintCost.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Contracts.Repository
{
    public interface IPriceRepository
    {
        List<Price> GetPricesByPaper(int paperSizeId, List<int> jobTypes);
    }
}
