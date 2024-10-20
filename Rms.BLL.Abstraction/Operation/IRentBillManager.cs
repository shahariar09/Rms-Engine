using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.SP;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation.RentBill;
using Rms.Models.Request.Operation.RentBill;
using Rms.Models.ReturnDto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Operation
{
    public interface IRentBillManager:IManager<RentAndUtilityBill>
    {
        Task<IList<GeneratedRentBill>> GenerateRentBill(int customerId);
        Task<Result> CreateRentBill(RentAndUtilityBillCreateDto model);
        Task<IList<RentAnUtilityBillSummaryView>> GetRentAndUtilityBillByCustomer(BillCriteriaDto model);
    }
}
