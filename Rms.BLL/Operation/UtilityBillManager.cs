using AutoMapper;
using Rms.BLL.Abstraction.Operation;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Operation.RentBill;
using Rms.Models.Request.Operation;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Abstraction.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Operation
{
    public class UtilityBillManager : Manager<UtilityBill>, IUtilityBillManager
    {
        private readonly IUtilityBillRepository _utilityBillRepository;
        private readonly IRentBillRepository _rentBillRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;


        public UtilityBillManager(
            IMapper mapper, IUtilityBillRepository utilityBillRepository,
            IRentBillRepository rentBillRepository,
            ICustomerRepository customerRepository
            ) : base(utilityBillRepository)
        {
            _utilityBillRepository = utilityBillRepository;
            _mapper = mapper;
            _rentBillRepository = rentBillRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Result> AddUtilityBill(UtilityBillCreateDto model)
        {

            var utilityBill = _mapper.Map<UtilityBill>(model);


            utilityBill.BillNo = GenerateBillNo().ToString();
            bool isAdded = await _utilityBillRepository.Add(utilityBill);

            if (isAdded)
            { 
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }

        public async Task<IList<UtilityBillSummaryView>> GetUtilityBillByCriteria(BillCriteriaDto model)
        {
            var data = _utilityBillRepository.GetUtilityBillByCriteria(model).ToList();

            if (data.Any())
            {

                return data;
            }
            else
            {
                return new List<UtilityBillSummaryView>();
            }
        }

        public string GenerateBillNo()
        {
            var lastBill = _utilityBillRepository.GetLast().Result;
            string paddedId;
            if (lastBill == null)
            {
                paddedId = 1.ToString().PadLeft(5, '0');
            }
            else
            {
                paddedId = (lastBill.Id + 1).ToString().PadLeft(5, '0');
            }
            return "UB" + paddedId;
        }

        
    }
}
