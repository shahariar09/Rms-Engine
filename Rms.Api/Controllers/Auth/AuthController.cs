using AutoMapper;
using Rms.Models.Common;
using Rms.Models.IdentityDto;
using Rms.Repo.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rms.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IdentityRepository _identityService;

      
        private readonly IMapper _mapper;
        public AuthController(IdentityRepository identityService,
                                IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            try
            {
                var result = await _identityService.Login(loginDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[AllowAnonymous]
        //[HttpPost("autoLoginByUserId/{userId}")]
        //public async Task<IActionResult> autoLoginByUserId(int userId)
        //{
        //    try
        //    {
        //        var result = await _identityService.AutoLoginByUserId(userId);

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [AllowAnonymous]
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(PasswordUpdateDto model)
        {
            try
            {
                var result = await _identityService.UpdatePassword(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("partner-register")]
        public async Task<IActionResult> Register(UserForRegisterDto registerDto)
        {
            try
            {
                var result = await _identityService.Register(registerDto);

                if (result.Result.Succeeded)
                {

                    return Ok(result.UserId);
                }
                return BadRequest(result.Result.Errors);

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }




        [AllowAnonymous]
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



        [AllowAnonymous]
        [HttpPost("admin-register")]
        public async Task<IActionResult> AdminRegister(UserForRegisterDto registerDto)
        {

            var result = await _identityService.AdminRegister(registerDto);

            if (result.Result.Succeeded)
                return Ok(result.UserId);

            return BadRequest(result.Result.Errors);

        }

    }
}