using Microsoft.AspNetCore.Http;
using Rms.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Configuration.Services
{
    public class CurrentUserService : ICurrentUser
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName);
            Mobile = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.MobilePhone);
            ClientId = httpContextAccessor.HttpContext?.Request.Headers["ClientId"];
        }

        public string UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Mobile { get; }
        public string ClientId { get; }
    }
}
