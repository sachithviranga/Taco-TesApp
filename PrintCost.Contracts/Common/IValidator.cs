using PrintCost.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Contracts.Common
{
    public interface IValidator<in T>
    {
        bool Validate(T obj, out Message messages);
    }
}
