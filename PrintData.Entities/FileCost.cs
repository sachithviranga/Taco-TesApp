using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Entities
{
    public class FileCost
    {
        public List<PrintOutCount> PrintOutCounts { get; set; }
        public Decimal Cost { get; set; }

        public int TotalPages { get; set; }

        public Boolean IsDoubleSide { get; set; }
    }
}
