using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rms.BLL.Abstraction.Operation;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.SP;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Models.Request.Operation;
using Rms.Models.ReturnDto.Operation;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Abstraction.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Operation
{
    public class ElectricBillManager : Manager<ElectricBill>, IElectricBillManager
    {
        private readonly IElectricBillRepository _electricBillRepository;
        private readonly IRentBillRepository _rentBillRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;


        public ElectricBillManager(
            IMapper mapper, IElectricBillRepository electricBillRepository,
            IRentBillRepository rentBillRepository,
            ICustomerRepository customerRepository
            ) : base(electricBillRepository)
        {
            _electricBillRepository = electricBillRepository;
            _mapper = mapper;
            _rentBillRepository = rentBillRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Result> AddElectricBill(ElectricBillCreateDto model)
        {
            
            //if (await _electricBillRepository.BillExistanceCheck(model.CustomerId, model.IssueDate))
            //{
            //    return Result.Failure(new[] { "Bill already generated!" });
            //}
            var electricBill = _mapper.Map<ElectricBill>(model);


            electricBill.BillNo = GenerateBillNo().ToString();
            bool isAdded = await _electricBillRepository.Add(electricBill);

            if (isAdded)
            {
                var customer = await _customerRepository.GetById(electricBill.CustomerId);
                customer.ElectricMetterLastReading = electricBill.PresentReading;
                customer.ElectricMetterLastReadingDate = electricBill.IssueDate;
                await _customerRepository.Update(customer);
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }

        public async Task<IList<ElectricBillSummaryView>> GetElectricBillByCriteria(BillCriteriaDto model)
        {
            var data = _electricBillRepository.GetElectricBillByCriteria(model).ToList();

            if (data.Any()) 
            {
               
                return data;
            }
            else
            {
                return new List<ElectricBillSummaryView>();
            }
        }

        




        public string GenerateBillNo()
        {
            var lastBill = _electricBillRepository.GetLast().Result;
            string paddedId;
            if (lastBill == null)
            {
                paddedId = 1.ToString().PadLeft(5, '0');
            }
            else
            {
                paddedId = (lastBill.Id + 1).ToString().PadLeft(5, '0');
            }
            return "EB" + paddedId;
        }
    }
}
