using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Menues;
using Rms.Models.Request.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Menus
{
    public interface IUserMenuManager : IManager<UserMenu>
    {
        Task<Result> AddOrUpdate(UserMenuPermissionDto model);
        Task<long[]> GetPermitedMenuByUserId(long UserId);
    }
}
