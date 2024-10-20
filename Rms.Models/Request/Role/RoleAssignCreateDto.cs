using Rms.Models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Models.Request.Role
{
    public class RoleAssignCreateDto
    {
        public int userId { get; set; }
        public List<string> role { get; set; }
    }
}
