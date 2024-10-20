using Rms.Models.ReturnDto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Operation
{
    public interface ICommonOperaionRepository
    {
        Task<DueArrearReturnDto> GetCustomerWiseDueArrear(int billType, int customerId, DateTime date);
    }
}
