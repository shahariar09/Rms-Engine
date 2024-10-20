using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.IdentityDto
{
    public class UserForRegisterDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
    }
}
