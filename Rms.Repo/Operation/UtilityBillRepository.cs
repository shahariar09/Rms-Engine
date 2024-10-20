using Rms.Database.Database;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Base;

namespace Rms.Repo.Operation
{
    public class UtilityBillRepository : Repository<UtilityBill>, IUtilityBillRepository
    {
        private readonly ApplicationDbContext _context;

        public UtilityBillRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> Add(UtilityBill model)
        {
            _context.Add(model);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<UtilityBill> GetLast()
        {
            return _context.UtilityBills.OrderByDescending(c => c.Id).FirstOrDefault();
        }

        public IQueryable<UtilityBillSummaryView> GetUtilityBillByCriteria(BillCriteriaDto model)
        {
            var data = _context.UtilityBillSummariesView.Where(c => c.CustomerId == model.CustomerId ).AsQueryable();
            if (model.BillPayStatus != null)
            {
                data = data.Where(c => c.BillPayStatus == model.BillPayStatus );
            }
            return data;
        }



        public async Task<bool> BillExistanceCheck(int CustomerId, DateTime IssueDateTime)
        {
            var result = _context.UtilityBills.Where(p => p.CustomerId == CustomerId && p.IssueDate.Value.Month == IssueDateTime.Month && p.IssueDate.Value.Year == IssueDateTime.Year).FirstOrDefault();

            return result != null ? true : false;
        }
    }
}
