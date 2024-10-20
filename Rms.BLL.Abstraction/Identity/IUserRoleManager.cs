using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Identity;
using Rms.Models.Request.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Identity
{
    public interface IUserRoleManager : IManager<UserRole>
    {
        Task<Result> ClientWiseRoleAssign(int userId, string roleName, int clientId);
        Task<Result> RoleAssign(RoleAssignCreateDto roleAssign);
        Task<IList<int>> GetUserIdsByRole(string role);
    }
}
