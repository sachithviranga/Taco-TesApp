using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Entities
{
    public class PrintOutCount
    {
        Dictionary<int, string> PrintTypeLabels = new Dictionary<int, string>() { { 1, "Black & White" }, { 2, "Colour" }, };

        public int PrintTypeId { get; set; }
        public int Count { get; set; }

        public decimal Cost { get; set; }

        public string PrintTypeName
        {
            get { return PrintTypeLabels[PrintTypeId]; }
        }
    }
}
