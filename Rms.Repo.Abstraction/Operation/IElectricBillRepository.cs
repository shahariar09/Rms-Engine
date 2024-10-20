using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Models.Request.Operation;
using Rms.Models.ReturnDto.Operation;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Operation
{
    public interface IElectricBillRepository: IRepository<ElectricBill>
    {
        IQueryable<ElectricBillSummaryView> GetElectricBillByCriteria(BillCriteriaDto model);
        Task<ElectricBill> GetLast();
        Task<bool> BillExistanceCheck(int CustomerId, DateTime IssueDateTime);
    }
}
