using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Menues
{
    [Table("RMS_MENU")]
    public class Menu
    {
        public long Id { get; set; }
        public long? MenuId { get; set; }
        public int? Order { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
        public bool Root { get; set; }
        public string? Translate { get; set; }
        public string? Bullet { get; set; }
        public virtual IList<Menu> Submenu { get; set; }
    }
}
