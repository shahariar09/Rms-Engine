using Rms.BLL.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rms.Models.Entities.Menues;
using Rms.BLL.Abstraction.Menus;
using Rms.Repo.Abstraction.Menus;

namespace Rms.BLL.Menus
{
    public class MenuManager: Manager<Menu>, IMenuManager
    {
        IMenuRepository _repository;

        public MenuManager(IMenuRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<IList<Menu>> GetMenuList(string role)
        {
            var results = await _repository.GetAllMenu(role);

            var mainMenu = new List<Menu>();

            foreach (var result in results)
            {
                if (result.MenuId == null)
                {
                    mainMenu.Add(result);
                }
            }
            return mainMenu;
        }

        public async Task<IList<Menu>> GetPermitedMenuByRoles(IList<string> roles)
        {
            var results = await _repository.GetPermitedMenuByRoles(roles);

            var mainMenu = new List<Menu>();

            foreach (var result in results)
            {
                if (result.MenuId == null)
                {
                    mainMenu.Add(result);
                }
            }
            return mainMenu;
        }

        public async Task<IList<Menu>> GetPermitedMenuByUser(long userId)
        {
            var results = await _repository.GetPermitedMenuByUser(userId);

            var mainMenu = new List<Menu>();

            foreach (var result in results)
            {
                if (result.MenuId == null)
                {
                    mainMenu.Add(result);
                }
            }
            return mainMenu;
        }

        

        public Task<IList<Menu>> GetTopMenu()
        {
            return _repository.GetTopMenu();
        }
    }
}
