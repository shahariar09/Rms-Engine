using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rms.BLL.Abstraction.Operation;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.Entities.Operation;
using Rms.Models.Enums;
using Rms.Models.Request.Operation;
using Rms.Models.Request.Operation.RentBill;


namespace Rms.Api.Controllers.Operation
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BillGenerateController : ControllerBase
    {
        private readonly IElectricBillManager _electricBillManager; 
        private readonly IRentBillManager _rentBillManager; 
        private readonly IUtilityBillManager _utilityBillManager;
        private readonly ICommonOperaionManager _commonOperaionManager;

        public BillGenerateController(
            ICommonOperaionManager commonOperaionManager,
            IElectricBillManager electricBillManager,
            IRentBillManager rentBillManager,
            IUtilityBillManager utilityBillManager)
        {
         
            _electricBillManager = electricBillManager;
            _rentBillManager = rentBillManager;
            _utilityBillManager = utilityBillManager;
            _commonOperaionManager = commonOperaionManager;
        }

        //Electric Bill
        [HttpPost]
        public async Task<IActionResult> CreateElectricBill(ElectricBillCreateDto electricBillDto)
        {
            var result = await _electricBillManager.AddElectricBill(electricBillDto);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet()]
        public async Task<IActionResult> GetElectricBillByCriteria([FromQuery] BillCriteriaDto model)
        {
            var customer = await _electricBillManager.GetElectricBillByCriteria(model);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet()]
        public async Task<IActionResult> GetCustomerWiseDueArrear(int billType, int customerId,DateTime date)
        {
            var customer = await _commonOperaionManager.GetCustomerWiseDueArrear(billType,customerId, date);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        //Rent Bill
        [HttpPost]
        public async Task<IActionResult> CreateRentBill(RentAndUtilityBillCreateDto model)
        {
            var customer = await _rentBillManager.CreateRentBill(model);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
        [HttpGet()]
        public async Task<IActionResult> GetRentAndUtilityBillByCustomer([FromQuery] BillCriteriaDto model)
        {
            var rentAndUtilityBill = await _rentBillManager.GetRentAndUtilityBillByCustomer(model);

            if (rentAndUtilityBill == null)
            {
                return NotFound();
            }

            return Ok(rentAndUtilityBill);
        }
        [HttpGet()]
        public async Task<IActionResult> GenerateRentBill(int customerId)
        {
            var customer = await _rentBillManager.GenerateRentBill(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        //Utility Bill
        [HttpPost]
        public async Task<IActionResult> CreateUtilityBill(UtilityBillCreateDto electricBillDto)
        {
            var result = await _utilityBillManager.AddUtilityBill(electricBillDto);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet()]
        public async Task<IActionResult> GetUtilityBillByCriteria([FromQuery] BillCriteriaDto model)
        {
            var customer = await _utilityBillManager.GetUtilityBillByCriteria(model);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        //Get by id
        [HttpGet()]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _electricBillManager.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
