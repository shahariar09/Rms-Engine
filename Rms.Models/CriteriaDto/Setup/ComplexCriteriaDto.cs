using Rms.Models.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.CriteriaDto.Setup
{
    public class ComplexCriteriaDto
    {
        public ComplexCriteriaDto()
        {
            PageParams = new PageParams();
        }

        public string? Name { get; set; }
        public int? UserId { get; set; }

        public PageParams PageParams
        {
            get; set;
        }
    }
}
