using Rms.Models.Common.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Models.CriteriaDto.Role
{
    public class RoleCriteriaDto
    {
        public RoleCriteriaDto()
        {
            PageParams = new PageParams();
        }
        public long Id { get; set; }

        public PageParams PageParams { get; set; }
    }
}
