using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rms.BLL.Abstraction.Setup;
using Rms.BLL.Setup;
using Rms.Database.Database;
using Rms.Models.Entities.Setup;
using Rms.Models.Request.Setup;

namespace Rms.Api.Controllers.Setup
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerManager _customerManager;
 

        public CustomerController(IMapper mapper, ICustomerManager customerManager)
        {
            _mapper = mapper;
            _customerManager = customerManager;
     
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CustomerCreateOrUpdateDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var result = await _customerManager.Add(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(int id, [FromForm] CustomerCreateOrUpdateDto customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }
            var customer = _mapper.Map<Customer>(customerDto);

            var result = await _customerManager.Update(customer);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Conflict(result.Errors[0]);

        }

        [HttpGet()]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerManager.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet()]
        public async Task<IActionResult> GetByComplexId(int complexId)
        {
            var customer = await _customerManager.GetByComplexId(complexId);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerManager.GetAll();

            if (customers.Count()>0 && customers.Any())
            {
                return Ok(customers);
                
            }
            return NotFound();
        }
        [HttpGet()]
        public async Task<IActionResult> GetCustomerWithServiceBill()
        
        {
            try
            {
                var customers = await _customerManager.GetCusotmerWithServiceBill();

                if (customers.Count() > 0 && customers.Any())
                {
                    return Ok(customers);

                }
                return NotFound();
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCustomerOpeningElectricMeterReading(int customerId, CustomerOpeningElectricMeterReadingUpdateDto model)
        {
            if (customerId == null)
            {
                return BadRequest();
            }

            var result = await _customerManager.UpdateCustomerOpeningElectricMeterReading(customerId, model);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Conflict(result.Errors[0]);

        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCustomerActiveDate(int customerId, CustomerActiveDateUpdateDto model)
        {
            if (customerId == null)
            {
                return BadRequest();
            }

            var result = await _customerManager.UpdateCustomerActiveDate(customerId, model);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Conflict(result.Errors[0]);
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateCustomerAdvance(int customerId, CustomerActiveDateUpdateDto model)
        {
            if (customerId == null)
            {
                return BadRequest();
            }

            var result = await _customerManager.UpdateCustomerAdvance(customerId, model);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Conflict(result.Errors[0]);
        }
    }
}
