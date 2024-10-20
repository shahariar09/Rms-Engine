using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.ReturnDto.Operation
{
    public class DueArrearReturnDto
    {
        public decimal? PreviousDueAmount { get; set; }
        public decimal? ArrearAmount { get; set; }
    }
}
