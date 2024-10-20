using Rms.Models.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.CriteriaDto.Operation
{
    public class BillCriteriaDto
    {
        public BillCriteriaDto()
        {
            PageParams = new PageParams();
        }
        public int CustomerId { get; set; }
        public bool? BillPayStatus { get; set; }
        
        public PageParams PageParams
        {
            get; set;
        }
    }
}
