using AutoMapper;
using Rms.BLL.Abstraction.Operation;
using Rms.Models.ReturnDto.Operation;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Abstraction.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Operation
{
    public class CommonOperaionManager: ICommonOperaionManager
    {
        private readonly ICommonOperaionRepository _commonOperaionRepository;
 




        public CommonOperaionManager(ICommonOperaionRepository commonOperaionRepository) 
        {
            _commonOperaionRepository= commonOperaionRepository;
        }

        public async Task<DueArrearReturnDto> GetCustomerWiseDueArrear(int billType, int customerId, DateTime date)
        {
            return await _commonOperaionRepository.GetCustomerWiseDueArrear(billType, customerId, date);
        }
    }
}
