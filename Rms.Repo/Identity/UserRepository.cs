using Rms.Database.Database;
using Rms.Models.Common;

using Rms.Models.Entities.Identity;

using Rms.Repo.Abstraction.Identity;
using Rms.Repo.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rms.Models.IdentityDto;

namespace Rms.Repo.Identity
{
    public class UserRepository:Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUser _currentUser;


        public UserRepository(ApplicationDbContext db, UserManager<User> userManager, ICurrentUser currentUser) : base(db)
        {
            _db = db;
            _userManager = userManager;
            _currentUser = currentUser;
        }

        public IQueryable<User> GetByCriteria(UserCriteriaDto criteriaDto)
        {
            var data = _db.Users.Where(c => c.IsSoftDelete == false)
                                    .AsQueryable();

            string clientId = _currentUser.ClientId;
           

            if (!string.IsNullOrEmpty(criteriaDto.FullName))
            {
                data = data.Where(c => c.FullName.Contains(criteriaDto.FullName.Replace("--", " ").Trim()));
            }
            
            
            if (!string.IsNullOrEmpty(criteriaDto.UserName))
            {
                data = data.Where(c => c.UserName.Contains(criteriaDto.UserName.Replace("--", " ").Trim()));
            }
            if (!string.IsNullOrEmpty(criteriaDto.PhoneNumber))
            {
                data = data.Where(c => c.PhoneNumber.Contains(criteriaDto.PhoneNumber.Replace("--", " ").Trim()));
            }
            if (!string.IsNullOrEmpty(criteriaDto.Email))
            {
                data = data.Where(c => c.Email.Contains(criteriaDto.Email.Replace("--", " ").Trim()));
            }


            if (criteriaDto.PageParams != null)
            {
                if (!string.IsNullOrWhiteSpace(criteriaDto.PageParams.SearchKey))
                {
                    string searchKey = criteriaDto.PageParams.SearchKey.Replace("--", " ").Trim().ToLower();
                    data = data.Where(c => c.FullName.ToLower().Contains(searchKey)
                            || c.UserName.ToLower().Contains(searchKey)
                            || c.PhoneNumber.Contains(searchKey)
                            || c.Email.ToLower().Contains(searchKey)
                    );
                }
            }

            return data.OrderByDescending(c => c.Id);
        }

        public async Task<IList<string>> getRoleNames(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<User> GetUserById(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);
           
            return result;
        }

        

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            var result = await _userManager.Users.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);

            return result;
        }


    }
}
