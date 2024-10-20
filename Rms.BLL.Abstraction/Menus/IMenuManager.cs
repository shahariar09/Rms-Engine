using Rms.BLL.Abstraction.Base;
using System;
using Rms.Models.Entities.Menues;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Menus
{
    public interface IMenuManager: IManager<Menu>
    {
        Task<IList<Menu>> GetMenuList(string role);
        Task<IList<Menu>> GetTopMenu();
        Task<IList<Menu>> GetPermitedMenuByRoles(IList<string> roles);
        Task<IList<Menu>> GetPermitedMenuByUser(long userId);
    }
}
