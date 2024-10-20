using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Models.Request.Menus
{
    public class RoleMenuPermissionDto
    {
        public RoleMenuPermissionDto()
        {
            MenuIds = new List<long>();
        }

        public string RoleName { get; set; }
        public List<long> MenuIds { get; set; }
    }
}
