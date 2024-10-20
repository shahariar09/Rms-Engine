using Rms.Models.Entities.Operation;
using Rms.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Abstraction.Operation
{
    public interface IBillCollectionRepository: IRepository<BillCollection>
    {
        Task<BillCollection> GetLast();
    }
}
