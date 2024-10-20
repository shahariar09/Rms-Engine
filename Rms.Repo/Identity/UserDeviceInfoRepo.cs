using Rms.Database.Database;
using Rms.Models.Entities.Identity;
using Rms.Repo.Abstraction.Identity;
using Rms.Repo.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Repo.Identity
{
    public class UserDeviceInfoRepo: Repository<UserDeviceInfo>, IUserDeviceInfoRepo
    {
        private readonly ApplicationDbContext _db;
        public UserDeviceInfoRepo(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
    }
}
