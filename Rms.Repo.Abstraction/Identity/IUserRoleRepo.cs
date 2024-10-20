using Rms.Models.Entities.Identity;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Identity
{
    public interface IUserRoleRepo : IRepository<UserRole>
    {
        Task<bool> CheckHasRole(int userId, int roleName);
        Task<bool> CheckHasRoleClientWise(int userId, int roleId, int clientId);
        Task<bool> DeleteRoleForUserClientWise(int userId, int clientId);
        Task<IList<string>> GetRolesByUserId(int id);
        Task<IList<int>> GetUserIdsByRole(string role);
    }
}
