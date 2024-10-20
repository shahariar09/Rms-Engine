using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Operation;
using Rms.Models.Request.Operation.RentBill;
using Rms.Models.ReturnDto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Operation
{
    public interface ICommonOperaionManager
    {
        Task<DueArrearReturnDto> GetCustomerWiseDueArrear(int billType, int customerId, DateTime date);
    }
}
