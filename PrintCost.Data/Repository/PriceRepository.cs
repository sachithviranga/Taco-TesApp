using AutoMapper;
using PrintCost.Context;
using PrintCost.Contracts.Repository;
using PrintCost.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Data.Repository
{
    public class PriceRepository : IPriceRepository
    {
        private readonly PrintCostContext _context;

        private readonly IMapper _mapper;

        public PriceRepository(PrintCostContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Price> GetPricesByPaper(int paperSizeId, List<int> jobTypes)
        {
            var prices = _context.PcPrice.Where(a => a.PcPaperSizeId == paperSizeId && jobTypes.Any(s => s == a.PcJobTypeId) && a.IsActive == true).ToList();
            return _mapper.Map<List<PcPrice>, List<Price>>(prices);
        }
    }
}
