using Rms.Database.Database;
using Rms.Models.Common;
using Rms.Models.Entities.Identity;
using Rms.Repo.Abstraction.Identity;
using Rms.Repo.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Identity
{
    public class UserRoleRepo: Repository<UserRole>, IUserRoleRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _currentUserService;
        public UserRoleRepo(ApplicationDbContext db, ICurrentUser currentUser) : base(db)
        {
            _db = db;
            _currentUserService = currentUser;
        }

        public async Task<bool> CheckHasRole(int userId, int roleId)
        {
            int clientId = Convert.ToInt32(_currentUserService.ClientId);
            var data = await _db.UserRoles.Where(c => c.IsSoftDelete == false && c.RoleId == roleId && c.UserId == userId && c.ClientId==clientId).FirstOrDefaultAsync();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> CheckHasRoleClientWise(int userId, int roleId, int clientId)
        {
            
            var data = await _db.UserRoles.Where(c => c.IsSoftDelete == false && c.RoleId == roleId && c.UserId == userId && c.ClientId == clientId).FirstOrDefaultAsync();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteRoleForUserClientWise(int userId, int clientId)
        {

            var data = await _db.UserRoles.Where(c => c.IsSoftDelete == false && c.UserId == userId && c.ClientId == clientId).ToListAsync();
            if (data != null)
            {
               _db.UserRoles.RemoveRange(data);
                //_db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IList<string>> GetRolesByUserId(int id)
        {
            int clientId = Convert.ToInt32(_currentUserService.ClientId);

            var data = await _db.UserRoles.Where(c => c.IsSoftDelete == false && c.UserId == id )
                .Select(c=>c.RoleId)     
                .ToListAsync();
            var roles = await _db.Roles.Where(c => c.IsSoftDelete == false && data.Contains(c.Id)).Select(c => c.Name).ToListAsync();
            //var b = data.Select(c => c.Role.Name).ToList();
            return roles;
        }

        public async Task<IList<int>> GetUserIdsByRole(string role)
        {
            int clientId = Convert.ToInt32(_currentUserService.ClientId);
            // int clientId = 1;
            var roleId =await _db.Roles.Where(c => c.Name == role).Select(c => c.Id).FirstOrDefaultAsync();
            var data = _db.UserRoles.AsQueryable();
            var d = await data.Where(c => c.IsSoftDelete == false && c.RoleId==roleId)
                .Select(c => c.UserId)
                .ToListAsync();
           
            //var b = data.Select(c => c.Role.Name).ToList();
            return d;
        }
    }
}
