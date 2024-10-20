using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Operation
{
    public interface IUtilityBillRepository:IRepository<UtilityBill>
    {
        IQueryable<UtilityBillSummaryView> GetUtilityBillByCriteria(BillCriteriaDto model);
        Task<UtilityBill> GetLast();
        Task<bool> BillExistanceCheck(int CustomerId, DateTime IssueDateTime);
    }
}
