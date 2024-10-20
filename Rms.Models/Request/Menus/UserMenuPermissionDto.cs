using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Request.Menus
{
    public class UserMenuPermissionDto
    {
        public long UserId { get; set; }
        public List<long> MenuIds { get; set; }
    }
}
