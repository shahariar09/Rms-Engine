using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Models.Common.Identity
{
     public class NotFoundException: Exception
    {
        public NotFoundException(string name, object key)
           : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
