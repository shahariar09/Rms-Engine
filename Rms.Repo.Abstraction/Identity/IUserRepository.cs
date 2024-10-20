using Rms.Models.Entities.Identity;
using Rms.Models.IdentityDto;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Identity
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserById(string userId);
        public Task<IList<string>> getRoleNames(User user);
        Task<User> GetUserByPhoneNumber(string phoneNumber);
        IQueryable<User> GetByCriteria(UserCriteriaDto criteriaDto);
    }
}
