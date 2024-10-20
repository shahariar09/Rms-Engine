using AutoMapper;
using Rms.BLL.Abstraction.Identity;
using Rms.Models.CriteriaDto.Role;
using Rms.Models.Request.Menus;
using Rms.Models.ReturnDto.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rms.BLL.Abstraction.Menus;
using Rms.BLL.Menus;


namespace Rms.Api.Controllers.menues
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuManager _menuManager;
        private readonly IRoleMenuManager _roleMenuManger;
        private readonly IUserMenuManager _userMenuManger;
        IMapper _mapper;
        //private readonly ICodeGenerationManager _codeGenerationManager;

        private readonly IUserRoleManager _userRoleManager;
        public MenuController(IUserRoleManager userRoleManager, IUserMenuManager userMenuManger, IMenuManager menuManager, IMapper mapper, IRoleMenuManager roleMenuManager)
        {
            _menuManager = menuManager;
            _mapper = mapper;
            _roleMenuManger = roleMenuManager;
            _userMenuManger = userMenuManger;

            //_codeGenerationManager = codeGenerationManager;

            _userRoleManager = userRoleManager;

        }

        [HttpGet("getPermitedMenu/{role}")]
        public async Task<IActionResult> GetMenuList(string role)
        {
            var result = await _menuManager.GetMenuList(role);
            return Ok(result);
        }

        [HttpGet("getPermitedMenuByRoles")]
        public async Task<IActionResult> GetPermitedMenuByRoles([FromQuery] RoleList roles)
        {
            if (roles != null)
            {
                var result = await _menuManager.GetPermitedMenuByRoles(roles.RoleNames);

                var ff = _mapper.Map<IList<MenuReturnDto>>(result);
                

                return Ok(result);
            }
            else
            {
                return NotFound("Not found");
            }           
        }

        [HttpGet("GetPermitedMenuByUser/{userId}")]
        public async Task<IActionResult> GetPermitedMenuByUser(int userId)
        {
            if (userId != null)
            {
                var result = await _menuManager.GetPermitedMenuByUser(userId);

                var ff = _mapper.Map<IList<MenuReturnDto>>(result);


                return Ok(result);
            }
            else
            {
                return NotFound("Not found");
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _menuManager.GetAll();
            return Ok(result);
        }

        [HttpPut("roleMenuPermission")]
        public async Task<IActionResult> RoleMenuPermission([FromBody] RoleMenuPermissionDto model)
        {
            if (ModelState.IsValid)
            {
               
               var userIds = await _userRoleManager.GetUserIdsByRole(model.RoleName);
                //var clientId = Request.Headers["ClientId"].ToString();
                var result = await _roleMenuManger.AddOrUpdate(model);
              
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut("userMenuPermission")]
        public async Task<IActionResult> UserMenuPermission(UserMenuPermissionDto model)
        {
            if (ModelState.IsValid)
            {

               
                //var clientId = Request.Headers["ClientId"].ToString();
                var result = await _userMenuManger.AddOrUpdate(model);

                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("getPermitedMenuIds")]
        public async Task<IActionResult> GetMenuIdsAsync(string roleName)
        {
            var request = Request.Headers;
            var result = await _roleMenuManger.GetPermitedMenuIds(roleName);

            return Ok(result);
        }

        [HttpGet("getPermitedMenuByUserId")]
        public async Task<IActionResult> getPermitedMenuByUserId(int userId)
        {
            var request = Request.Headers;
            var result = await _userMenuManger.GetPermitedMenuByUserId(userId);

            return Ok(result);
        }

        [HttpGet("getTopMenu")]
        public async Task<IActionResult> GetTop()
        {
            var result = await _menuManager.GetTopMenu();
            return Ok(result);
        }

        

        

      
    }
}
