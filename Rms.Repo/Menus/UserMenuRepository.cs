using Rms.Database.Database;
using Rms.Models.Common;
using Rms.Models.Entities.Menues;
using Rms.Repo.Abstraction.Menus;
using Rms.Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Menus
{
    public class UserMenuRepository : Repository<UserMenu>, IUserMenuRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _currentUser;
        public UserMenuRepository(ApplicationDbContext db, ICurrentUser currentUser) : base(db)
        {
            _db = db;
            _currentUser = currentUser;
        }
        public async Task<long[]> GetPermitedMenuByUserId(long userId)
        {
            var result =   _db.UserMenus.Where(c => c.UserId == userId && c.IsSoftDelete == false).Select(c => c.MenuId).ToArray();
            return result;
        }
    }
}



