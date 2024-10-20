using Rms.BLL.Abstraction.Identity;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Identity;
using Rms.Models.Request.Role;
using Rms.Repo.Abstraction.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Rms.BLL.Identity
{
    public class UserRoleManager: Manager<UserRole>, IUserRoleManager
    {
        private readonly IUserRoleRepo _repo;
        private readonly RoleManager<Role> _roleManager;
        private readonly ICurrentUser _currentUser;
        public UserRoleManager(IUserRoleRepo repo, RoleManager<Role> roleManager, ICurrentUser currentUser) : base(repo)
        {
            _repo = repo;
            _roleManager = roleManager;
            _currentUser = currentUser;
        }
        public async Task<IList<int>> GetUserIdsByRole(string role)
        {
            var userIds = await _repo.GetUserIdsByRole(role);
            return userIds;
        }
        public async Task<Result> ClientWiseRoleAssign(int userId, string roleName, int clientId)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            UserRole userRole = new UserRole
            {
                RoleId = role.Id,
                UserId = userId,
                ClientId = clientId
            };
            var hasrole = await _repo.CheckHasRoleClientWise(userId, role.Id, clientId);
            if (hasrole)
            {
                return Result.Success();
            }
            var result = await _repo.Add(userRole);
            if (result)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Failed role assign" });

        }

       

        public async Task<Result> RoleAssign(RoleAssignCreateDto roleAssign)
        {
            var userRoles = new List<UserRole>();
            int clientId = Convert.ToInt32(_currentUser.ClientId);
            foreach (var data in roleAssign.role)
            {
                var name = String.Concat(data.Where(c => !Char.IsWhiteSpace(c)));
                var role = await _roleManager.FindByNameAsync(name);
                UserRole userRole = new UserRole
                {
                    RoleId = role.Id,
                    UserId = roleAssign.userId,
                    ClientId = clientId
                };
                
                    userRoles.Add(userRole);
               
            }

            var deleteResult = await _repo.DeleteRoleForUserClientWise(roleAssign.userId, clientId);
            var result = await _repo.AddRangeAsync(userRoles);
            if (result)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Failed role assign" });
        }
    }
}
