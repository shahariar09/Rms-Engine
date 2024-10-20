
using Rms.BLL.Abstraction.Identity;
using Rms.BLL.Base;
using Rms.Models.Common.Paging;
using Rms.Models.Entities.Identity;
using Rms.Models.IdentityDto;
using Rms.Repo.Abstraction.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Identity
{
    public class UserManager : Manager<User>, IUserManager
    {
        private readonly IUserRepository _repositories;
      
        public UserManager(IUserRepository repositories) : base(repositories)
        {
            _repositories = repositories;
        }

       

        public async Task<PagedList<User>> GetByCriteria(UserCriteriaDto criteriaDto)
        {
            var data = _repositories.GetByCriteria(criteriaDto);

            if (criteriaDto != null)
            {
                var result = await PagedList<User>.CreateAsync(data, criteriaDto.PageParams.PageNumber, criteriaDto.PageParams.PageSize);
                return result;
            }
            else
            {
                var totalDataCount = data.Count();

                return new PagedList<User>(data.ToList(), data.Count(), 1, totalDataCount);
            }
        }

      







    }
}
