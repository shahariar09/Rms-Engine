using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.ReturnDto.Permissions
{
    public class PermissionReturnDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long PermissionFeatureId { get; set; }
        public bool HasLimit { get; set; }
        public long? Limit { get; set; }
        public long? RelationId { get; set; }
    }
}
