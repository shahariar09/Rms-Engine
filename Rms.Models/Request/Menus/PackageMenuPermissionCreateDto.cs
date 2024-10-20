using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Models.Request.Menus
{
    public class PackageMenuPermissionCreateDto
    {
        public PackageMenuPermissionCreateDto()
        {
            MenuIds = new List<long>();
        }

        public long ClassroomPackageId { get; set; }
        public List<long> MenuIds { get; set; }
    }
}
