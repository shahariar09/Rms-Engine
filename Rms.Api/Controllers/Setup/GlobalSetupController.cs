using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rms.BLL.Abstraction.Setup;
using Rms.Models.Entities.Setup;
using Rms.Models.Request.Setup;

namespace Rms.Api.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalSetupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGlobalSetupManager _globalSetupManager;

        public GlobalSetupController(IMapper mapper, IGlobalSetupManager globalSetupManager)
        {
            _mapper = mapper;
            _globalSetupManager = globalSetupManager;
        }
       

        [HttpPost]
        public async Task<IActionResult> Create(GlobalSetupCreateOrUpdateDto globalSetupDto)
        {
            var globalSetup = _mapper.Map<GlobalSetup>(globalSetupDto);
           
            if (globalSetup.Id != 0)
            {
                var result = await _globalSetupManager.Update(globalSetup);
            }
            else
            {
                var result = await _globalSetupManager.Add(globalSetup);
            }
            return CreatedAtAction(nameof(GetById), new { id = globalSetup.Id }, globalSetup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GlobalSetupCreateOrUpdateDto globalSetupDto)
        {
            if (id != globalSetupDto.Id)
            {
                return BadRequest();
            }
            var globalSetup = _mapper.Map<GlobalSetup>(globalSetupDto);

            var result = await _globalSetupManager.Update(globalSetup);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Conflict(result.Errors[0]);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var globalSetup = await _globalSetupManager.GetFirstorDefault(c => c.IsSoftDelete == false);

                if (globalSetup == null)
                {
                    return NotFound();
                }

                return Ok(globalSetup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var globalSetup = await _globalSetupManager.GetById(id);

            if (globalSetup == null)
            {
                return NotFound();
            }

            return Ok(globalSetup);
        }
    }
}
