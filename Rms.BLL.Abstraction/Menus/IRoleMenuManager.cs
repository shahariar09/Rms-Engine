using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Menues;
using Rms.Models.Request.Menus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Menus
{
    public interface IRoleMenuManager : IManager<RoleMenu>
    {
        Task<Result> AddOrUpdate(RoleMenuPermissionDto model);
        Task<long[]> GetPermitedMenuIds(string roleName);

        //Task<ICollection<Rms.Models.Entities.Menues.Menu>> GetTopMenu();
        Task<List<int>> GetMenuWieseUsers(long menuId);
    }
}
