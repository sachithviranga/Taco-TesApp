using System;
using System.Collections.Generic;

#nullable disable

namespace PrintCost.Context
{
    public partial class PcJobType
    {
        public PcJobType()
        {
            PcPrice = new HashSet<PcPrice>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<PcPrice> PcPrice { get; set; }
    }
}
