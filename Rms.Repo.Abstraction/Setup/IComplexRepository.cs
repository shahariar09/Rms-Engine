using Rms.Models.Common.Paging;
using Rms.Models.CriteriaDto.Setup;
using Rms.Models.Entities.Setup;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Setup
{
    public interface IComplexRepository:IRepository<Complex>
    {
        IQueryable<Complex> GetByCriteria(ComplexCriteriaDto criteriaDto);
    }
}
