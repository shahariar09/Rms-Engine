using Rms.Models.Entities.Menues;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Menus
{
    public interface IMenuRepository: IRepository<Menu>
    {
        Task<IList<Menu>> GetAllMenu(string role);
        Task<IList<Menu>> GetTopMenu();
        Task<IList<Menu>> GetPermitedMenuByRoles(IList<string> roles);
        Task<IList<Menu>> GetPermitedMenuByUser(long userId);
        
    }
}
