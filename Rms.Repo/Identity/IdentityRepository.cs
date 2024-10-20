using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rms.Database.Database;
using Rms.Models.Common;
using Rms.Models.Common.Identity;
using Rms.Models.Entities.Identity;
using Rms.Models.IdentityDto;
using Rms.Models.ReturnDto.Permissions;
using Rms.Repo.Abstraction.Identity;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Rms.Models.Common.Paging;


namespace Rms.Repo.Identity
{
    public class IdentityRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<User> _signInManager;
        private readonly ICurrentUser _currentUserService;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserRoleRepo _userRoleRepo;

        public IdentityRepository(ApplicationDbContext context, UserManager<User> userManager, IConfiguration config,
            SignInManager<User> signInManager, ICurrentUser currentUserService, IUserRoleRepo userRoleRepo,
        RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
            _currentUserService = currentUserService;
            _roleManager = roleManager;
            _userRoleRepo = userRoleRepo;
        }

        public async Task<PagedList<User>> GetAllUser(UserCriteriaDto criteriaDto)
        {
            var data = _context.Users.AsQueryable();
            var result = await PagedList<User>.CreateAsync(data, criteriaDto.PageParams.PageNumber, criteriaDto.PageParams.PageSize);
            return result;
        }

        public async Task<UserReturnDto> GetByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            //var user = await _userManager.FindByIdAsync(id);
            var role = await _userManager.GetRolesAsync(user);
            var userReturnDto = new UserReturnDto
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email

            };
            return userReturnDto;
        }


        public async Task<object> Login(UserLoginDto userForLogin)
        {
            if (!string.IsNullOrWhiteSpace(userForLogin.UserName) && !string.IsNullOrWhiteSpace(userForLogin.Password))
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.UserName == userForLogin.UserName);

                //var user = await _userManager.FindByNameAsync(userForLogin.Mobile);

                if (user == null)
                {
                    throw new UnauthorizedAccessException("User not found! Please register");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, userForLogin.Password, false);

                if (result.Succeeded)
                {
                    //var role = await _userManager.GetRolesAsync(user);
                    var role = await _userRoleRepo.GetRolesByUserId(user.Id);
                    UserReturnDto appUser = new UserReturnDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email

                    };

                    return new
                    {
                        token = await GenerateJwtToken(user),
                        user = appUser
                    };
                }
                throw new UnauthorizedAccessException("Invalid username or password");
            }
            throw new NotFoundException(nameof(User), userForLogin.UserName);
        }


        public async Task<object> AutoLoginByUserId(int userId)
        {
            if (userId > 0)
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == userId);

                //var user = await _userManager.FindByNameAsync(userForLogin.Mobile);

                if (user == null)
                {
                    throw new UnauthorizedAccessException("User not found! Please register");
                }

                // var result = await _signInManager.CheckPasswordSignInAsync(user, userForLogin.Password, false);

                if (user != null)
                {
                    //var role = await _userManager.GetRolesAsync(user);
                    var role = await _userRoleRepo.GetRolesByUserId(user.Id);
                    UserReturnDto appUser = new UserReturnDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email

                    };

                    return new
                    {
                        token = await GenerateJwtToken(user),
                        user = appUser
                    };
                }
                throw new UnauthorizedAccessException("Invalid username or password");
            }
            throw new NotFoundException(nameof(User), userId);
        }


        public async Task<List<Role>> GetAllRole()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return roles;
        }




        public async Task<User> UpdatePassword(PasswordUpdateDto model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user == null)
                {
                    throw new Exception("User is not found while try to reset password.");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, model.OldPassword, false);
                if (result.Succeeded)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);

                    var update = await _userManager.UpdateAsync(user);

                    if (!update.Succeeded)
                    {
                        throw new Exception("Unable to update password.");
                    }

                    return user;
                }
                else
                {
                    throw new UnauthorizedAccessException("Invalid password"); ;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<(Result Result, int UserId)> Register(UserForRegisterDto userForRegister)
        {

            var checkPhone = await _context.Users.FirstOrDefaultAsync(c => c.UserName == userForRegister.UserName);
            if (checkPhone != null)
                return (Result.Failure(new List<string> { "Phone number Already Taken" }), checkPhone.Id);

            var lastUser = await _context.Users.OrderByDescending(c => c.Id).FirstOrDefaultAsync();

            var UserCode = DateTime.Now.Year + DateTime.Now.Month.ToString("d2");

            var user = new User
            {
                FullName = userForRegister.FullName,
                UserName = userForRegister.UserName,
                CreatedOn = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, userForRegister.Password);

            if (result.Succeeded)
            {

                var assignRole = await AssginRole(user.Id, "Admin", 0);
            }

            return (result.ToApplicationResult(), user.Id);
        }


        public async Task<(Result Result, int UserId)> CreateUser(UserCreateDto userForRegister)
        {
            if (string.IsNullOrWhiteSpace(userForRegister.UserName))
            {
                return (Result.Failure(new[] { "Username cannot be empty" }), 0);
            }


            var user = new User
            {
                FullName = userForRegister.FullName,
                Email = userForRegister.Email,
                UserName = userForRegister.UserName,
                CreatedOn = DateTime.Now,
                PhoneNumber = userForRegister.PhoneNumber,
                Address = userForRegister.Address
            };

            var result = await _userManager.CreateAsync(user, userForRegister.Password);
            return (result.ToApplicationResult(), user.Id);









        }
        public async Task<(Result Result, int UserId)> BecomeInstructor(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            if (user != null)
            {
                //var role = await _userManager.GetRolesAsync(user);
                var roleOb = await _roleManager.FindByNameAsync("Instructor");
                var hasRole = await _userRoleRepo.CheckHasRole(user.Id, roleOb.Id);
                //if (role.Contains("Instructor"))
                if (hasRole)
                {
                    return (Result.Success("Already Instructor role assign"), user.Id);
                }
                //var result = await _userManager.AddToRolesAsync(user, new[] { "Instructor" });
                //if(result.)
                var clientId = _currentUserService.ClientId;
                var result = await AssginRole(user.Id, "Instructor", Convert.ToInt32(clientId));

                return (result, user.Id);
            }

            throw new UnauthorizedAccessException("Invalid user");

            //registration process for instructor as user

            //instructor assign to user


        }



        public async Task<(Result Result, int UserId)> AdminRegister(UserForRegisterDto userForRegister)
        {


            var checkPhone = await _context.Users.FirstOrDefaultAsync(c => c.UserName == userForRegister.UserName);
            if (checkPhone != null)
                return (Result.Failure(new List<string> { "User name Already Taken" }), checkPhone.Id);

            var user = new User
            {
                FullName = userForRegister.FullName,
                UserName = userForRegister.UserName,
            };

            var result = await _userManager.CreateAsync(user, userForRegister.Password);

            if (result.Succeeded)
            {

                await _userManager.AddToRolesAsync(user, new[] { "Admin" });
            }

            return (result.ToApplicationResult(), user.Id);
        }
        public async Task<User> GetUserById(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);
            return result;
        }
        public async Task<User> Update(User model, string newPassword)
        {

            if (!System.String.IsNullOrEmpty(newPassword.Trim()))
            {
                model.PasswordHash = _userManager.PasswordHasher.HashPassword(model, newPassword);
            }

            var result = await _userManager.UpdateAsync(model);

            if (!result.Succeeded)
            {
                throw new Exception("Unable to update information");
            }

            return model;
        }

        public async Task<User> AdminResetPassword(AdminResetPasswordDto model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user == null)
                {
                    Result.Failure(new List<string> { "Phone number Already Taken" });
                    throw new Exception("User is not found while try to reset password");
                }

                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);

                var update = await _userManager.UpdateAsync(user);

                if (!update.Succeeded)
                {
                    throw new Exception("Unable to update password");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result> AddOrUpdateUserRole(int userId, List<string> roleNames)
        {
            try
            {

                List<UserRole> userRoles = new List<UserRole>();
                foreach (var name in roleNames)
                {
                    var role = await _roleManager.FindByIdAsync(name);
                    UserRole userRole = new UserRole
                    {
                        RoleId = role.Id,
                        UserId = userId,
                        //  ClientId = clientId
                    };
                    userRoles.Add(userRole);
                }


                //var result = await _userRoleRepo.Add(userRole);
                var existingRoles = _context.UserRoles.Where(c => c.UserId == userId).ToList();
                _context.UserRoles.RemoveRange(existingRoles);
                await _context.SaveChangesAsync();


                await _context.UserRoles.AddRangeAsync(userRoles);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Result.Success();
                }
                return Result.Failure(new[] { "Failed role assign" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),

            };

            var roles = await _userRoleRepo.GetRolesByUserId(user.Id);


            string clientId = _currentUserService.ClientId;

            var permissionData = await _context.RoleFeaturePermissions.Where(c => roles.Contains(c.UserRoles) && c.IsSoftDelete == false && c.ClientId == Convert.ToInt32(clientId))
                        .Include(c => c.Permission).ToListAsync();
            ICollection<PermissionReturnDto> permissionReturn = new List<PermissionReturnDto>();

            if (permissionData != null)
            {
                foreach (var permission in permissionData)
                {
                    var item = new PermissionReturnDto()
                    {
                        Id = permission.Permission.Id,
                        RelationId = permission.Id,
                        Code = permission.Permission.Code,
                        Limit = permission.Limit,
                        PermissionFeatureId = permission.Permission.PermissionFeatureId,
                        Name = permission.Permission.Name
                    };
                    permissionReturn.Add(item);
                }
            }

            var data = JsonSerializer.Serialize(permissionReturn);

            // end
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var authToken = tokenHandler.WriteToken(token);

            var newClaim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),

            };
            newClaim.Add(new Claim("Permissions", data));
            newClaim.Add(new Claim("AuthToken", authToken));

            var newtokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(newClaim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var newtoken = tokenHandler.CreateToken(newtokenDescriptor);

            return tokenHandler.WriteToken(newtoken);
        }

        public async Task<Result> CreateRole(string roleName)
        {
            try
            {
                Role role = new Role
                {
                    Name = roleName
                };
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return Result.Success();
                }
                return Result.Failure(new[] { "Failed role create" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async Task<Result> AssginRole(int userId, string roleName, int clientId)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                //var role = await _roleManager.FindByIdAsync(1.ToString());
                UserRole userRole = new UserRole
                {
                    RoleId = role.Id,
                    UserId = userId,
                    ClientId = clientId
                };

                //var result = await _userRoleRepo.Add(userRole);

                var isAdded = await _context.UserRoles.AddAsync(userRole);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Result.Success();
                }
                return Result.Failure(new[] { "Failed role assign" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
