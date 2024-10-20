using Rms.BLL.Abstraction.Menus;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Menues;
using Rms.Models.Request.Menus;
using Rms.Repo.Abstraction.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Menus
{
    public class UserMenuManager : Manager<UserMenu>, IUserMenuManager
    {
        private readonly IUserMenuRepo _repo;

        //private readonly IRoleMenuManager _roleMenuManger;
        public UserMenuManager(IUserMenuRepo repo) : base(repo)
        {
            _repo = repo;
            //_roleMenuManger = roleMenuManger;
        }

        public async Task<Result> AddOrUpdate(UserMenuPermissionDto entity)
        {
            try
            {
               

                if (entity.MenuIds == null || !entity.MenuIds.Any())
                {
                    return Result.Failure(new[] { "No menu provided while adding menu permission!" });
                }

                var menuPermissionforThisUser = _repo.Get(c => c.UserId == entity.UserId && c.IsSoftDelete == false);

                var existingMenuIds = menuPermissionforThisUser.Select(c => c.MenuId).ToList();

                var addableMenueIds = entity.MenuIds.Where(menuId => existingMenuIds.All(c => c != menuId));

                var deleteableMenuIds = existingMenuIds.Where(menuId => entity.MenuIds.All(c => c != menuId));

                var addeableMenuPermissions = new List<UserMenu>();
                var deleteableMenuPermissions = new List<UserMenu>();

                if (addableMenueIds.Any())
                {
                    foreach (var menuId in addableMenueIds)
                    {
                        var item = new UserMenu()
                        {
                            MenuId = menuId,
                            UserId = entity.UserId,

                        };

                        addeableMenuPermissions.Add(item);
                    }
                }

                             if (deleteableMenuIds.Any())
                {
                    deleteableMenuPermissions = menuPermissionforThisUser.Where(c => c.UserId == entity.UserId && deleteableMenuIds.Contains(c.MenuId)).ToList();
                }

                bool isAdded = false;
                bool isRemoved = false;

                if (addeableMenuPermissions.Any())
                {
                    isAdded = await _repo.AddRangeAsync(addeableMenuPermissions);
                }

                if (deleteableMenuPermissions.Any())
                {
                    isRemoved = await _repo.RemoveRangeAsync(deleteableMenuPermissions);
                }
                if (isAdded || isRemoved)
                {
                    return Result.Success();
                }
                return Result.Failure(new[] { "menu permission not update!" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Task<long[]> GetPermitedMenuByUserId(long userId)
        {
            return _repo.GetPermitedMenuByUserId(userId);
        }



    }
}
