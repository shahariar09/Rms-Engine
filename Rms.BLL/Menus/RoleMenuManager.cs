
using Rms.BLL.Abstraction.Menus;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Menues;
using Rms.Models.Request.Menus;
using Rms.Repo.Abstraction.Menus;


namespace Rms.BLL.Menus
{
    public class RoleMenuManager: Manager<RoleMenu>, IRoleMenuManager
    {
        private readonly IRoleMenuRepo _repo;

        //private readonly IRoleMenuManager _roleMenuManger;
        public RoleMenuManager(IRoleMenuRepo repo) : base(repo)
        {
            _repo = repo;
            //_roleMenuManger = roleMenuManger;
        }

        public async Task<Result> AddOrUpdate(RoleMenuPermissionDto entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.RoleName))
                {
                    return Result.Failure(new[] { "No Role provided while adding menu permission!" });
                }

                if (entity.MenuIds == null || !entity.MenuIds.Any())
                {
                    return Result.Failure(new[] { "No menu provided while adding menu permission!" });
                }

                var menuPermissionforThisRole = _repo.Get(c => c.Role == entity.RoleName && c.IsSoftDelete==false);

                var existingMenuIds = menuPermissionforThisRole.Select(c => c.MenuId).ToList();

                var addableMenueIds = entity.MenuIds.Where(menuId => existingMenuIds.All(c => c != menuId));

                var deleteableMenuIds = existingMenuIds.Where(menuId => entity.MenuIds.All(c => c != menuId));

                var addeableMenuPermissions = new List<RoleMenu>();
                var deleteableMenuPermissions = new List<RoleMenu>();

                if (addableMenueIds.Any())
                {
                    foreach (var menuId in addableMenueIds)
                    {
                        var item = new RoleMenu()
                        {
                            MenuId = menuId,
                            Role = entity.RoleName,
                        
                        };

                        addeableMenuPermissions.Add(item);
                    }
                }

                if (deleteableMenuIds.Any())
                {
                    deleteableMenuPermissions = menuPermissionforThisRole.Where(c => c.Role == entity.RoleName && deleteableMenuIds.Contains(c.MenuId)).ToList();
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
                if(isAdded || isRemoved)
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

       

        
        

        public async Task<List<int>> GetMenuWieseUsers(long menuId)
        {
            return await _repo.GetMenuWieseUsers(menuId);
        }

        public Task<long[]> GetPermitedMenuIds(string roleName)
        {
            return _repo.GetPermitedMenuIds(roleName);
        }

        //public Task<ICollection<Models.Entities.Menues.Menu>> GetTopMenu()
        //{
        //    return _repo.GetTopMenu();
        //}
    }
}
