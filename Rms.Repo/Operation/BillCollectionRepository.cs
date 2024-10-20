using Rms.Database.Database;
using Rms.Models.Entities.Operation;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Operation
{
    public class BillCollectionRepository : Repository<BillCollection>, IBillCollectionRepository
    {
        private readonly ApplicationDbContext _context;

        public BillCollectionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<bool> Add(BillCollection model)
        { 
            _context.Add(model);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<BillCollection> GetLast()
        {
            return _context.BillCollections.OrderByDescending(c => c.Id).FirstOrDefault();
        }
    }
}
