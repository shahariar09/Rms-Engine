using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Rms.Database.Database;
using Rms.Models.DbModels.SP;
using Rms.Models.Entities.Setup;
using Rms.Models.Enums;
using Rms.Models.ReturnDto.Operation;
using Rms.Repo.Abstraction.Operation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Operation
{
    public class CommonOperaionRepository : ICommonOperaionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CommonOperaionRepository(ApplicationDbContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }


        public async Task<DueArrearReturnDto> GetCustomerWiseDueArrear(int billType, int customerId, DateTime date)
        {
            using (var _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                _connection.Open();

                var param = new Dapper.DynamicParameters();
                param.Add("@CustomerId", customerId, System.Data.DbType.Int32);
                param.Add("@BillDate", date, System.Data.DbType.DateTime);
                param.Add("@BillType", billType, System.Data.DbType.Int32);


                var result = await _connection.QuerySingleOrDefaultAsync<DueArrearReturnDto>("SP_GET_DUE_ARREAR_AMOUNT", param, commandType: CommandType.StoredProcedure);

                _connection.Close();

                return result;
            }
        }
    }
}
