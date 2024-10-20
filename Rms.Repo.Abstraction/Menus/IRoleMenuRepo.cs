using Rms.Models.Entities.Menues;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Menus
{
    public interface IRoleMenuRepo : IRepository<RoleMenu>
    {
        Task<long[]> GetPermitedMenuIds(string roleName);
        Task<IList<RoleMenu>> GetPermitedMenuesByClientId(int clientId);
        //Task<ICollection<Models.Entities.Menues.Menu>> GetTopMenu();
        Task<List<int>> GetMenuWieseUsers(long menuId);
    }
}
