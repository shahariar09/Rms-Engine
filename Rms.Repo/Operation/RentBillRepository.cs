using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Rms.Database.Database;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.SP;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Operation.RentBill;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Rms.Models.Common;
using Rms.Models.Request.Operation.RentBill;
using Microsoft.EntityFrameworkCore;
using Rms.Models.DbModels.Views;

namespace Rms.Repo.Operation
{
    public class RentBillRepository : Repository<RentAndUtilityBill>, IRentBillRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public RentBillRepository(ApplicationDbContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration;
        }

        public List<GeneratedRentBill> GenerateRentBill(int customerId)
        {
            



            using (var _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                _connection.Open();

                var param = new Dapper.DynamicParameters();
                param.Add("@CustomerId", customerId, System.Data.DbType.Int32);


                var result = _connection.Query<GeneratedRentBill>("SP_GENERATE_BILL", param, commandType: CommandType.StoredProcedure).ToList();

                _connection.Close();

                return result;
            }
        }

        public async Task<Result> CreateRentBill(RentAndUtilityBill model)
        {
            await _context.RentAndUtilityBills.AddAsync(model);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return Result.Success();
            }
            return Result.Failure(new List<string> { "Failed to update data" });

        }

        public async Task<RentAndUtilityBill> GetLast()
        {
            return _context.RentAndUtilityBills.OrderByDescending(c => c.Id).FirstOrDefault();
        }

        public IQueryable<RentAnUtilityBillSummaryView> GetRentAndUtilityBillByCustomer(BillCriteriaDto model)
        {
            var data = _context.RentAnUtilityBillSummariesView
                .Where(c => c.CustomerId == model.CustomerId && c.BillCollectStatus == false)
                .AsQueryable();
            return data;
        }


    }
}
