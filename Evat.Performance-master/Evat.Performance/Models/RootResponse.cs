using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evat.Performance.Models
{
    public class RESPONSE
    {
        public string STATUS { get; set; }
        public string TAXPAYER_TIN { get; set; }
        public string ERROR_CODE { get; set; }

        public string DISTRIBUTOR_TIN { get; set; }
    }

    public class RootResponse
    {
        public RESPONSE RESPONSE { get; set; }
    }
}
