using PrintCost.Contracts.Common;
using PrintCost.Contracts.FileHandler;
using PrintCost.Contracts.Manager;
using PrintCost.Contracts.Repository;
using PrintCost.Entities;
using PrintCost.Entities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrintCost.Common.Constant;

namespace PrintCost.Business.Manager
{
    public class CalculateCostManager : ICalculateCostManager
    {
        private readonly IFileReader _fileReader;

        private readonly IPriceRepository _priceRepository;

        private readonly IValidator<CostCalculate> _costCalculateValidator;

        private readonly IMapper<Message, ServiceResponse> _serviceResponseErrorMapper;

        private readonly IMapper<Object, ServiceResponse> _serviceResponseMapper;

        public CalculateCostManager(IFileReader fileReader, IPriceRepository priceRepository, IValidator<CostCalculate> costCalculateValidator, IMapper<Message, ServiceResponse> serviceResponseErrorMapper, IMapper<object, ServiceResponse> serviceResponseMapper)
        {
            _fileReader = fileReader;
            _priceRepository = priceRepository;
            _costCalculateValidator = costCalculateValidator;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        public ServiceResponse CalculateCost(CostCalculate costCalculate)
        {
            if (!_costCalculateValidator.Validate(costCalculate, out Message message))
            {
                return _serviceResponseErrorMapper.Map(message);
            }

            FileCost fileCost = new();

            List<int> jobTypes = new();

            if (costCalculate.IsDoubleSide)
            {
                jobTypes.Add((int)JobType.DBW);
                jobTypes.Add((int)JobType.DC);
            }
            else
            {
                jobTypes.Add((int)JobType.SBW);
                jobTypes.Add((int)JobType.SC);
            }

            var prices = _priceRepository.GetPricesByPaper((int)PaperSize.A4, jobTypes);

            fileCost.PrintOutCounts = _fileReader.GetPrintOutCounts(costCalculate);
            fileCost.IsDoubleSide = costCalculate.IsDoubleSide;
            fileCost.Cost = 0;

            if (fileCost.PrintOutCounts.Any() && prices.Any())
            {
                if (fileCost.PrintOutCounts.Any(a => a.PrintTypeId == (int)PrintType.BW && a.Count > 0))
                {
                    int jobTypeId = costCalculate.IsDoubleSide ? (int)JobType.DBW : (int)JobType.SBW;
                    decimal cost = 0;
                    var printOut = fileCost.PrintOutCounts.Single(a => a.PrintTypeId == (int)PrintType.BW);
                    var price = prices.SingleOrDefault(a => a.JobTypeId == jobTypeId);
                    if (price != null) cost = price.Cost;
                    printOut.Cost = cost * printOut.Count;
                    fileCost.Cost += printOut.Cost;
                    fileCost.TotalPages += printOut.Count;
                }

                if (fileCost.PrintOutCounts.Any(a => a.PrintTypeId == (int)PrintType.C && a.Count > 0))
                {
                    int jobTypeId = costCalculate.IsDoubleSide ? (int)JobType.DC : (int)JobType.SC;
                    decimal cost = 0;
                    var printOut = fileCost.PrintOutCounts.Single(a => a.PrintTypeId == (int)PrintType.C);
                    var price = prices.SingleOrDefault(a => a.JobTypeId == jobTypeId);
                    if (price != null) cost = price.Cost;
                    printOut.Cost = cost * printOut.Count;
                    fileCost.Cost += printOut.Cost;
                    fileCost.TotalPages += printOut.Count;
                }
            }

            return _serviceResponseMapper.Map(fileCost);
        }
    }
}
