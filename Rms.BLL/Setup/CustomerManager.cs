using Rms.BLL.Abstraction.Setup;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Setup;
using Rms.Models.Request.Setup;
using Rms.Repo.Abstraction.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Setup
{
    public class CustomerManager : Manager<Customer>, ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository CustomerRepository) : base(CustomerRepository)
        {
            _customerRepository = CustomerRepository;
        }

        public virtual async Task<Result> Add(Customer customer)
        {
            bool isAdded = await _customerRepository.Add(customer);

            if (isAdded)
            {
                
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }


        public async Task<Result> UpdateCustomerOpeningElectricMeterReading(int customerId, CustomerOpeningElectricMeterReadingUpdateDto model)
        {
            return await _customerRepository.UpdateCustomerOpeningElectricMeterReading(customerId, model);
        }
        public async Task<Result> UpdateCustomerActiveDate(int customerId, CustomerActiveDateUpdateDto model)
        {
            return await _customerRepository.UpdateCustomerActiveDate(customerId, model);
        }
        public async Task<Result> UpdateCustomerAdvance(int customerId, CustomerActiveDateUpdateDto model)
        {
            return await _customerRepository.UpdateCustomerAdvance(customerId, model);
        }

        



        public async Task<List<Customer>> GetByComplexId(int complexId)
        {
            var result =  _customerRepository.GetByComplexId(complexId);
            return result.ToList();
        }

        public async Task<List<CusotmerWithServiceBillView>> GetCusotmerWithServiceBill()
        {
            var result = _customerRepository.GetCusotmerWithServiceBill();
            return result.ToList();
        }

      
    }
}
