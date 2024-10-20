using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rms.Api.Common;
using Rms.BLL.Abstraction.Setup;
using Rms.BLL.Setup;
using Rms.Models.CriteriaDto.Setup;
using Rms.Models.Entities.Setup;
using Rms.Models.Request.Setup;
using Rms.Models.ReturnDto.Setup;

namespace Rms.Api.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IComplexManager _complexManager;

        public ComplexController(IMapper mapper, IComplexManager complexManager)
        {
            _mapper = mapper;
            _complexManager = complexManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ComplexCreateOrUpdateDto complexDto)
        {
            var complex = _mapper.Map<Complex>(complexDto);
            
            if (complexDto.Id != null)
            {
                var result = await _complexManager.Update(complex);
            }
            else
            {
                var result = await _complexManager.Add(complex);
            }
            return CreatedAtAction(nameof(GetById), new { id = complex.Id }, complex);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ComplexCreateOrUpdateDto complexDto)
        {
            if (id != complexDto.Id)
            {
                return BadRequest();
            }
            var complex = _mapper.Map<Complex>(complexDto);

            var result = await _complexManager.Update(complex);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Conflict(result.Errors[0]);

        }
        [HttpGet]
        public async Task<IActionResult> GetComplexs([FromQuery] ComplexCriteriaDto criteriaDto)
        {
            var result = await _complexManager.GetByCriteria(criteriaDto);
            if (result.Count() > 0)
            {
                var productsToReturn = _mapper.Map<List<ComplexReturnDto>>(result);
                var startCount = result.PageSize * (result.CurrentPage - 1);
                foreach (var product in productsToReturn)
                {
                    startCount = startCount + 1;
                    product.Sl = startCount;
                }

                Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
                return Ok(productsToReturn);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var complex = await _complexManager.GetById(id);

            if (complex == null)
            {
                return NotFound();
            }

            return Ok(complex);
        }
        [HttpDelete("DeleteComplex")]
        public async Task<IActionResult> DeleteComplex(int id)
        {
            var complex = await _complexManager.GetById(id);
            if (complex == null)
            {
                return BadRequest();
            }
            else
            {
                var result = await _complexManager.RemoveAsync(complex);
                if (result)
                {
                    return Ok();
                }
                return Ok();
            }
        }
    }
}
