using Rms.BLL.Abstraction.Setup;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Setup;
using Rms.Repo.Abstraction.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Setup
{
    public class GlobalSetupManager:Manager<GlobalSetup>, IGlobalSetupManager
    {
        private readonly IGlobalSetupRepository _customerRepository;

        public GlobalSetupManager(IGlobalSetupRepository GlobalSetupRepository) : base(GlobalSetupRepository)
        {
            _customerRepository = GlobalSetupRepository;
        }

        public virtual async Task<Result> Add(GlobalSetup customer)
        {
            bool isAdded = await _customerRepository.Add(customer);

            if (isAdded)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }
    }
}
