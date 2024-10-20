using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.Entities.Operation;
using Rms.Models.Request.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Abstraction.Operation
{
    public interface IBillCollectionManager : IManager<BillCollection>
    {
        Task<Result> AddBillCollection(BillCollectionCreateDto model);
    }
}
