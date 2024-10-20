using Rms.Models.Common;
using Rms.Models.Entities.Identity;
using Rms.Models.IdentityDto;
using Rms.Models.Request.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Rms.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly RoleManager<Role> roleManager;
        public AdministratorController(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

    
        [HttpPost("Role")]
        public async Task<IActionResult> Create(RoleCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var existingRoles = roleManager.Roles.Where(c => c.Name.ToLower() == model.Name.ToLower()).ToList();
               
               
                if (existingRoles.Any() && existingRoles.Count()>0)
                {
                    return BadRequest("Role name already exist " );
                }

                Role role = new Role
                {
                    Name = model.Name
                };

                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Ok();
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Ok(model);
        }

        [HttpGet("Role")]
        public IActionResult List()
        {
            var role = roleManager.Roles;

            return Ok(role);
        }

        [HttpGet("RoleById")]
        public IActionResult List(int id)
        {
            var role = roleManager.Roles.Where(c=>c.Id==id).FirstOrDefault();
            return Ok(role);
        }


        [HttpPut("Role")]
        public async Task<IActionResult> Edit(RoleCreateDto model)
        {
            var role = await roleManager.FindByIdAsync(model.Id.ToString());
            if (role == null)
            {
                return BadRequest();
            }
            else
            {
                role.Name = model.Name;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return Ok(role);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Ok(model);
        }

        [HttpDelete("Role")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return BadRequest();
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Ok();
                }

                return Ok();
            }


        }
    }
}
