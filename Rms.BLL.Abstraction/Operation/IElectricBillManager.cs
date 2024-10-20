using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.SP;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Setup;
using Rms.Models.Request.Operation;
using Rms.Models.ReturnDto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Operation
{
    public interface IElectricBillManager: IManager<ElectricBill>
    {
        Task<Result> AddElectricBill(ElectricBillCreateDto model);
        Task<IList<ElectricBillSummaryView>> GetElectricBillByCriteria(BillCriteriaDto model);
    }
}
