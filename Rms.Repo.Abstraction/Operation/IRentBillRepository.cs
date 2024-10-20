using Rms.Models.Common;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.SP;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Operation.RentBill;
using Rms.Models.Request.Operation.RentBill;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Operation
{
    public interface IRentBillRepository: IRepository<RentAndUtilityBill>
    {
        List<GeneratedRentBill> GenerateRentBill(int customerId);
        Task<Result> CreateRentBill(RentAndUtilityBill model);
        Task<RentAndUtilityBill> GetLast();
        IQueryable<RentAnUtilityBillSummaryView> GetRentAndUtilityBillByCustomer(BillCriteriaDto model);
    }
}
