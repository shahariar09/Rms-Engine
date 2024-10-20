using AutoMapper;
using Rms.Api.Common;
using Rms.BLL.Abstraction.Identity;
using Rms.Models.Common;
using Rms.Models.Entities.Identity;
using Rms.Models.IdentityDto;
using Rms.Repo.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Rms.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserRoleManager _userRoleManager;
        private readonly IdentityRepository _identityService;
        private readonly IUserManager _manager;
        public UserController(IdentityRepository identityService, IUserManager userManager, IMapper mapper, IConfiguration config, RoleManager<Role> roleManager, IUserRoleManager userRoleManager)
        {
            _manager = userManager;
            _mapper = mapper;
            _config = config;
            _roleManager = roleManager;
            _userRoleManager = userRoleManager;
            _identityService=identityService;
        }



        [AllowAnonymous]
        [HttpGet("getUserByUserName")]
        public async Task<IActionResult> GetUser(string userName)
        {

            var user = await _identityService.GetByUserName(userName);

            //var data = _mapper.Map<UserForReturnDto>(user);
            if (user != null)
                return Ok(user);

            return NotFound("Not found");
        }

        [AllowAnonymous]
        [HttpGet("getById/{userId}", Name = "getById")]
        public async Task<IActionResult> GetUserById(string UserId)
        {
            var user = await _identityService.GetUserById(UserId);

            //var data = _mapper.Map<UserForReturnDto>(user);
            if (user != null)
                return Ok(user);

            return NotFound("User Not Found");
        }

        [HttpGet("getme")]
        public async Task<IActionResult> GetMe()
        {
            var userId = GetUserId();
            var user = await _identityService.GetUserById(Convert.ToString(userId));

            //var data = _mapper.Map<UserForReturnDto>(user);
            if (user != null)
                return Ok(user);

            return NotFound("User Not Found");
        }

        protected long GetUserId()
        {
            var userId = this.User.Claims.FirstOrDefault()?.Value;

            return userId != null ? long.Parse(userId) : 0;
        }


        

        [HttpDelete()]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _identityService.GetUserById(id);
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                var result = await _manager.RemoveAsync(user);
                if (result==true)
                {
                    return Ok();
                }

                return BadRequest("Delete Failed.");
            }


        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody] UserCreateDto model)
        {
            var user = await _identityService.GetUserById(id);
            if (user != null)
            {
                //if (model.ImageFile != null)
                //{
                //    if (user.Image != null)
                //    {
                //        string image = Path.Combine(_config.GetValue<string>("FileUploads:RootPath"), "UserImage", user.Image);
                //        System.IO.File.Delete(image);
                //    }
                //    string imagePath = Path.Combine(_config.GetValue<string>("FileUploads:RootPath"), "UserImage");

                //    model.Image = await Extensions.ProcessUploadFileDefiniteLocationAsync(model.ImageFile, imagePath);
                //}
                //else
                //{
                //    model.Image = user.Image;
                //}

                var data = _mapper.Map(model, user);

                var result = await _manager.UpdateAsync(data);
               
               

                if (result==true)
                {
                    return CreatedAtRoute("getById", new { userId = data.Id }, _mapper.Map<UserReturnDto>(data));
                    //return Ok(result);
                }
            }
            return BadRequest("Not Found");
        }




        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto registerDto)
        {

            var result = await _identityService.CreateUser(registerDto);

            if (result.Result.Succeeded)
                return Ok(result);

            return BadRequest(result.Result.Errors);
        }

        [HttpPut("AdminPasswordReset")]
        public async Task<IActionResult> AdmicResetPassword(AdminResetPasswordDto model)
        {
            try
            {
                if (ModelState.IsValid && model.NewPassword == model.ConfirmPassword)
                {
                    var result = await _identityService.AdminResetPassword(model);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                }
                return BadRequest("Invalid Operation");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserCriteriaDto criteriaDto)
        {
            var users = await _manager.GetByCriteria(criteriaDto);

            if (users != null)
            {
                var data = _mapper.Map<IList<UserReturnDto>>(users);
                var startCount = users.StartCount;
                foreach (var user in data)
                {
                    
                    startCount = startCount + 1;
                    user.Sl = startCount;
                }
                Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

                return Ok(data);
            }
            else
            {
                return NotFound("Data not found");
            }
        }



        [HttpGet("assignRole/{userId}")]
        public async Task<IActionResult> AssignStudentRole(int userId,string roleName)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                UserRole userRole = new UserRole
                {
                    RoleId = role.Id,
                    UserId = userId,
                };

                var result = await _userRoleManager.AddAsync(userRole);
                if (result==true)
                {
                    return Ok(result);
                }
                return NotFound("not add");
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return BadRequest();
        }


  

    }
}
