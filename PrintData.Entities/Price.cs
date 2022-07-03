using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Entities
{
    public class Price
    {
        public int PaperSizeId { get; set; }
        public int JobTypeId { get; set; }
        public decimal Cost { get; set; }
    }
}
