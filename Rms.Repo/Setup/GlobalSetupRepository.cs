using Rms.Database.Database;
using Rms.Models.Entities.Setup;
using Rms.Repo.Abstraction.Setup;
using Rms.Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Setup
{
    public class GlobalSetupRepository : Repository<GlobalSetup>, IGlobalSetupRepository
    {
        private readonly ApplicationDbContext _context;

        public GlobalSetupRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<bool> Add(GlobalSetup customer)
        {
            _context.Add(customer);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
