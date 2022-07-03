using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Common
{
    public class Constant
    {
        public enum PaperSize
        {
            A4 = 1
        }

        public enum JobType
        {
            SBW = 1,
            DBW = 2,
            SC = 3,
            DC = 4
        }

        public enum PrintType
        {
            BW = 1 ,
            C = 2
        }

    }
}
