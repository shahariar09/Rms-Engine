using Rms.Models.Common;
using Rms.Models.Common.Paging;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Setup;
using Rms.Models.Request.Setup;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Setup
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        Task<Result> UpdateCustomerOpeningElectricMeterReading(int customerId, CustomerOpeningElectricMeterReadingUpdateDto model);
        Task<Result> UpdateCustomerActiveDate(int customerId, CustomerActiveDateUpdateDto model);
        Task<Result> UpdateCustomerAdvance(int customerId, CustomerActiveDateUpdateDto model);

        

        IQueryable<Customer> GetByComplexId(int complexId);
        IQueryable<CusotmerWithServiceBillView> GetCusotmerWithServiceBill();
        
    }
}
