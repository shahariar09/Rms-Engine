using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Models.Request.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Operation
{
    public interface IUtilityBillManager:IManager<UtilityBill>
    {
        Task<Result> AddUtilityBill(UtilityBillCreateDto model);
        Task<IList<UtilityBillSummaryView>> GetUtilityBillByCriteria(BillCriteriaDto model);
    }
}
