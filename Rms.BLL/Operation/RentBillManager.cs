using AutoMapper;
using Rms.BLL.Abstraction.Operation;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.SP;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Operation.RentBill;
using Rms.Models.Entities.Setup;
using Rms.Models.Request.Operation.RentBill;
using Rms.Models.ReturnDto.Operation;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Operation
{
    public class RentBillManager: Manager<RentAndUtilityBill>,IRentBillManager
    {
        private readonly IRentBillRepository _rentBillRepository;
        private readonly IMapper _mapper;


        public RentBillManager(IMapper mapper, IRentBillRepository rentBillRepository) : base(rentBillRepository)
        {
            _rentBillRepository = rentBillRepository;
            _mapper = mapper;
        }

        public async Task<IList<GeneratedRentBill>> GenerateRentBill(int customerId)
        {
            var data = _rentBillRepository.GenerateRentBill(customerId).ToList();

            if (data.Any())
            {
                
                return data;
            }
            else
            {
                return [];
            }
        }

        public async Task<Result> CreateRentBill(RentAndUtilityBillCreateDto model)
        {
            var RentAndUtilityBill = _mapper.Map<RentAndUtilityBill>(model);
            RentAndUtilityBill.BillNo = GenerateBillNo().ToString();

            var result = await _rentBillRepository.CreateRentBill(RentAndUtilityBill);

            return result;
        }

        public async Task<IList<RentAnUtilityBillSummaryView>> GetRentAndUtilityBillByCustomer(BillCriteriaDto model)
        {
            var data = _rentBillRepository.GetRentAndUtilityBillByCustomer(model).ToList();

            if (data.Any())
            {
               
                return data;
            }
            else
            {
                return new List<RentAnUtilityBillSummaryView>();
            }
        }



        public string GenerateBillNo()
        {
            var lastBill = _rentBillRepository.GetLast().Result;
            string paddedId;
            if (lastBill == null)
            {
                paddedId = 1.ToString().PadLeft(5, '0');
            }
            else
            {
                paddedId = (lastBill.Id + 1).ToString().PadLeft(5, '0');
            }
            return "RB" + paddedId;
        }
    }
}
