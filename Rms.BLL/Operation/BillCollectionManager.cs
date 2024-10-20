using AutoMapper;
using Rms.BLL.Abstraction.Operation;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Operation;
using Rms.Models.Enums;
using Rms.Models.Request.Operation;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Operation
{
    public class BillCollectionManager : Manager<BillCollection>, IBillCollectionManager
    {
        private readonly IBillCollectionRepository _billCollectionlRepository;
        private readonly IElectricBillRepository _electricBillRepository;
        private readonly IRentBillRepository _rentBillRepository;
        private readonly IUtilityBillRepository _utilityBillRepository;
        private readonly IMapper _mapper;


        public BillCollectionManager(
            IMapper mapper,
            IBillCollectionRepository billCollectionlRepository,
            IRentBillRepository rentBillRepository,
            IElectricBillRepository electricBillRepository,
            IUtilityBillRepository utilityBillRepository
            ) : base(billCollectionlRepository)
        {
            _billCollectionlRepository = billCollectionlRepository;
            _mapper = mapper;
            _rentBillRepository = rentBillRepository;
            _electricBillRepository = electricBillRepository;
            _utilityBillRepository = utilityBillRepository;
        }

        public async Task<Result> AddBillCollection(BillCollectionCreateDto model)
        {
            var isAdded = false;

            if (model.BillType == BillType.ElectricBill)
            {
                var existingCollection = await _billCollectionlRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);


                if (existingCollection != null)
                {
                    existingCollection.PaidAmount += model.PaymentAmount;
                    existingCollection.DueAmount -= model.PaymentAmount;

                    var electricBill = await _electricBillRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);
                    electricBill.BillPayStatus = true;
                    await _electricBillRepository.Update(electricBill);

                    await _billCollectionlRepository.Update(existingCollection);
                    return Result.Success();
                }
                else
                {
                    var billCollection = _mapper.Map<BillCollection>(model);
                    billCollection.InvoiceNo = GenerateBillNo().ToString();
                    billCollection.CollectionDate = DateTime.Now;
                    billCollection.PaidAmount = model.PaymentAmount;

                    var electricBill = await _electricBillRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);
                    electricBill.BillPayStatus = true;
                    await _electricBillRepository.Update(electricBill);

                    isAdded = await _billCollectionlRepository.Add(billCollection);
                }

            }
            if (model.BillType == BillType.RentAndUtilityBill)
            {


                var existingCollection = await _billCollectionlRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);


                if (existingCollection != null)
                {
                    existingCollection.PaidAmount += model.PaymentAmount;
                    existingCollection.DueAmount -= model.PaymentAmount;

                    var rentAndUtilityBill = await _rentBillRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);
                    rentAndUtilityBill.BillCollectStatus = true;
                    await _rentBillRepository.Update(rentAndUtilityBill);

                    await _billCollectionlRepository.UpdateAsync(existingCollection);
                    return Result.Success();
                }
                else
                {
                    var billCollection = _mapper.Map<BillCollection>(model);
                    billCollection.InvoiceNo = GenerateBillNo().ToString();
                    billCollection.CollectionDate = DateTime.Now;
                    billCollection.PaidAmount = model.PaymentAmount;

                    var rentBill = await _rentBillRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);
                    rentBill.BillCollectStatus = true;
                    await _rentBillRepository.Update(rentBill);

                    isAdded = await _billCollectionlRepository.Add(billCollection);
                }
            }
            if (model.BillType == BillType.UtilityBill)
            {


                var existingCollection = await _billCollectionlRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);


                if (existingCollection != null)
                {
                    existingCollection.PaidAmount += model.PaymentAmount;
                    existingCollection.DueAmount -= model.PaymentAmount;
                    
                        var rentAndUtilityBill = await _utilityBillRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);
                        rentAndUtilityBill.BillPayStatus = true;
                        await _utilityBillRepository.Update(rentAndUtilityBill);
                    
                    await _billCollectionlRepository.UpdateAsync(existingCollection);
                    return Result.Success();
                }
                else
                {
                    var billCollection = _mapper.Map<BillCollection>(model);
                    billCollection.InvoiceNo = GenerateBillNo().ToString();
                    billCollection.CollectionDate = DateTime.Now;
                    billCollection.PaidAmount = model.PaymentAmount;
                    //if (billCollection.TotalAmount == billCollection.PaidAmount)
                    //{
                        var rentBill = await _utilityBillRepository.GetFirstorDefault(c => c.BillNo == model.BillNo);
                        rentBill.BillPayStatus = true;
                        await _utilityBillRepository.Update(rentBill);
                    //}
                    isAdded = await _billCollectionlRepository.Add(billCollection);
                }
            }



            if (isAdded)
            {
                return Result.Success();
            }



            return Result.Failure(new[] { "Unable to save data!" });
        }

        public string GenerateBillNo()
        {
            var lastBill = _billCollectionlRepository.GetLast().Result;
            string paddedId;
            if (lastBill == null)
            {
                paddedId = 1.ToString().PadLeft(5, '0');
            }
            else
            {
                paddedId = (lastBill.Id + 1).ToString().PadLeft(5, '0');
            }
            return "IB" + paddedId;
        }
    }
}
