using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintCost.Contracts.Common;
using PrintCost.Contracts.Manager;
using PrintCost.Entities;
using PrintCost.Entities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCost.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCalculateController : ControllerBase
    {
        private readonly ICalculateCostManager _calculateCostManager;

        private readonly IMapper<Message, ServiceResponse> _serviceResponseErrorMapper;

        public CostCalculateController(ICalculateCostManager calculateCostManager, IMapper<Message, ServiceResponse> serviceResponseErrorMapper)
        {
            _calculateCostManager = calculateCostManager;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
        }

        [HttpPost]
        public ServiceResponse UploadFile([FromForm] CostCalculate costCalculate)
        {
            try
            {
                return _calculateCostManager.CalculateCost(costCalculate);

            }
            catch (Exception ex)
            {
                // error log
                return _serviceResponseErrorMapper.Map(new() { Code = "E0001", Description = "Service Error" });
            }
        }
    }
}
