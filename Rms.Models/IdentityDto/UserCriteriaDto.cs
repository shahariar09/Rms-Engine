﻿using Rms.Models.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.IdentityDto
{
    public class UserCriteriaDto
    {
        public UserCriteriaDto()
        {
            PageParams = new PageParams();
        }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? UserCode { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public PageParams PageParams
        {
            get; set;
        }
    }
}
