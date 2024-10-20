using Microsoft.AspNetCore.Mvc;
using Rms.BLL.Abstraction.Operation;
using Rms.BLL.Operation;
using Rms.Models.Request.Operation;

namespace Rms.Api.Controllers.Operation
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BillCollectionController : ControllerBase
    {

        private readonly IBillCollectionManager _billCollectionManager;

        public BillCollectionController(IBillCollectionManager billCollectionManager)
        {

            _billCollectionManager = billCollectionManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BillCollectionCreateDto model)
        {

            var result = await _billCollectionManager.AddBillCollection(model);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
