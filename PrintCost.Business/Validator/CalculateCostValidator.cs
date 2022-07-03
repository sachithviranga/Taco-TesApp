using PrintCost.Contracts.Common;
using PrintCost.Entities;
using PrintCost.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Business.Validator
{
    public class CalculateCostValidator : IValidator<CostCalculate>
    {
        public bool Validate(CostCalculate obj, out Message message)
        {
            message = new();
            if (obj.File == null || obj.File.Length == 0)
            {
                message = new() { Code = "E0002", Description = "Please upload file." };
                return false;
            }

            if (obj.File != null && !(obj.File.ContentType == "application/pdf" || obj.File.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
            {
                message = new() { Code = "E0003", Description = "Invalid file type." };
                return false;
            }

            return true;
        }
    }
}
