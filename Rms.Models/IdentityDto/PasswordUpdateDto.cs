﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.IdentityDto
{
    public class PasswordUpdateDto
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
