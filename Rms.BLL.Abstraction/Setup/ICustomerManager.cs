using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.Common.Paging;
using Rms.Models.CriteriaDto.Setup;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Setup;
using Rms.Models.Request.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Setup
{
    public interface ICustomerManager : IManager<Customer>
    {
        Task<List<Customer>> GetByComplexId(int complexId);
        Task<Result> UpdateCustomerOpeningElectricMeterReading(int customerId,CustomerOpeningElectricMeterReadingUpdateDto model);
        Task<Result> UpdateCustomerActiveDate(int customerId, CustomerActiveDateUpdateDto model);
        Task<Result> UpdateCustomerAdvance(int customerId, CustomerActiveDateUpdateDto model);
        Task<List<CusotmerWithServiceBillView>> GetCusotmerWithServiceBill();
        


    }
}
