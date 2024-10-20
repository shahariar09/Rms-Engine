using Rms.BLL.Abstraction.Base;
using Rms.Models.Common.Paging;
using Rms.Models.Entities.Identity;
using Rms.Models.IdentityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Identity
{
    public interface IUserManager : IManager<User>
    {
        Task<PagedList<User>> GetByCriteria(UserCriteriaDto criteriaDto);
    }
}
