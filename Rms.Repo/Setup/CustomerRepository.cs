using Microsoft.EntityFrameworkCore;
using Rms.Database.Database;
using Rms.Models.Common;
using Rms.Models.Common.Paging;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Setup;
using Rms.Models.Enums;
using Rms.Models.Request.Setup;
using Rms.Repo.Abstraction.Setup;
using Rms.Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Setup
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<bool> Add(Customer customer)
        {
            _context.Add(customer);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Result> UpdateCustomerOpeningElectricMeterReading(int customerId, CustomerOpeningElectricMeterReadingUpdateDto model)
        {


            var existingData = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (existingData != null)
            {
                existingData.OpeningReadingDate = model.OpeningReadingDate;
                existingData.OpeningReading = model.OpeningReading;
                _context.Customers.Update(existingData);
            }
                

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return Result.Success();
            }
            return Result.Failure(new List<string> { "Failed to update data" });
        }

        public async Task<Result> UpdateCustomerActiveDate(int customerId, CustomerActiveDateUpdateDto model)
        {


            var existingData = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (existingData != null)
            {
                existingData.RentActiveDate = model.RentActiveDate;
                existingData.AdvanceRentAmount = model.AdvanceRentAmount;
                existingData.DueAmount = model.DueAmount;

            }


            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return Result.Success();
            }
            return Result.Failure(new List<string> { "Failed to update data" });
        }

        public async Task<Result> UpdateCustomerAdvance(int customerId, CustomerActiveDateUpdateDto model)
        {


            var existingData = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (existingData != null)
            {
                if (model.ContactName != null)
                {
                    existingData.ContactName = model.ContactName;
                }
                existingData.AdvanceRentAmount = model.AdvanceRentAmount;
            }


            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return Result.Success();
            }
            return Result.Failure(new List<string> { "Failed to update data" });
        }


        public IQueryable<Customer> GetByComplexId(int complexId)
        {
            var data = _context.Customers
                .Where(c => c.IsSoftDelete == false && c.ComplexId == complexId).AsQueryable();
           
            return data.OrderBy(c => c.Name);
        }

        public IQueryable<CusotmerWithServiceBillView> GetCusotmerWithServiceBill()
        {
            var data = _context.CusotmerWithServiceBillsView.AsQueryable();

            return data;
        }

        



    }
}
