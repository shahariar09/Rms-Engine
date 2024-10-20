﻿using Rms.BLL.Abstraction.Base;
using Rms.Models.Common.Paging;
using Rms.Models.CriteriaDto.Setup;
using Rms.Models.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Setup
{
    public interface IComplexManager:IManager<Complex>
    {
        Task<PagedList<Complex>> GetByCriteria(ComplexCriteriaDto criteriaDto);
    }
}
