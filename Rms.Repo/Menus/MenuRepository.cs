using Rms.Database.Database;
using Rms.Models.Common;
using Rms.Repo.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rms.Repo.Abstraction.Menus;
using Rms.Models.Entities.Menues;

namespace Rms.Repo.Menus
{
    public class MenuRepository : Repository<Rms.Models.Entities.Menues.Menu>, IMenuRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _currentUser;
        public MenuRepository(ApplicationDbContext db, ICurrentUser currentUser) : base(db)
        {
            _db = db;
            _currentUser = currentUser;
        }
        public async Task<IList<Rms.Models.Entities.Menues.Menu>> GetAllMenu(string role)
        {
            int clientId = Convert.ToInt32(_currentUser.ClientId);
            long[] permitedMenuIds = _db.RoleMenus.Where(c => c.Role == role && c.IsSoftDelete == false).Select(c => c.MenuId).ToArray();
            return await _db.Menus.OrderBy(c => c.Order).Where(c => permitedMenuIds.Contains(c.Id)).ToListAsync();
        }

        public async Task<IList<Models.Entities.Menues.Menu>> GetPermitedMenuByRoles(IList<string> roles)
        {
            int clientId = Convert.ToInt32(_currentUser.ClientId);
            //int clientId = 1;
            long[] permitedMenuIds = _db.RoleMenus.Where(c => roles.Contains(c.Role) && c.IsSoftDelete == false).Select(c => c.MenuId).ToArray();
            return await _db.Menus.OrderBy(c => c.Order).Where(c => permitedMenuIds.Contains(c.Id)).ToListAsync();
        }

        public async Task<IList<Menu>> GetPermitedMenuByUser(long userId)
        {
 
            long[] permitedMenuIds = _db.UserMenus.Where(c => c.UserId == userId).Select(c => c.MenuId).ToArray();
  
            return await _db.Menus.OrderBy(c => c.Order).Where(c => permitedMenuIds.Contains(c.Id)).ToListAsync();
        }




        public async Task<IList<Models.Entities.Menues.Menu>> GetTopMenu()
        {

            var data = await _db.Menus.Where(c => c.MenuId == null).Include(c => c.Submenu).ToListAsync();
            return data;

        }
    }
}
