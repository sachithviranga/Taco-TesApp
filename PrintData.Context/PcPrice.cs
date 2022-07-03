using System;
using System.Collections.Generic;

#nullable disable

namespace PrintCost.Context
{
    public partial class PcPrice
    {
        public int Id { get; set; }
        public int PcPaperSizeId { get; set; }
        public int PcJobTypeId { get; set; }
        public decimal Cost { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual PcJobType PcJobType { get; set; }
        public virtual PcPaperSize PcPaperSize { get; set; }
    }
}
