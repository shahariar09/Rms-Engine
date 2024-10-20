using Rms.Models.Entities.Menues;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Menus
{
    public interface IUserMenuRepo : IRepository<UserMenu>
    {
        Task<long[]> GetPermitedMenuByUserId(long userId);
 
    }
}
