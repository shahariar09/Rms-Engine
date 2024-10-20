using Microsoft.EntityFrameworkCore;
using Rms.Database.Database;
using Rms.Models.CriteriaDto.Operation;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Operation.RentBill;
using Rms.Models.Request.Operation;
using Rms.Models.ReturnDto.Operation;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Repo.Operation
{
    public class ElectricBillRepository: Repository<ElectricBill>, IElectricBillRepository
    {
        private readonly ApplicationDbContext _context;

        public ElectricBillRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> Add(ElectricBill model)
        {
            _context.Add(model);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ElectricBill> GetLast()
        {
            return _context.ElectricBills.OrderByDescending(c=>c.Id).FirstOrDefault(); 
        }

        public IQueryable<ElectricBillSummaryView> GetElectricBillByCriteria(BillCriteriaDto model)
        {
            var data = _context.ElectricBillSummariesView.Where(c => c.CustomerId == model.CustomerId).AsQueryable();
            if (model.BillPayStatus!=null)
            {
                data = data.Where(c => c.BillPayStatus == model.BillPayStatus);
            }
            return data;
        }

      

        public async Task<bool> BillExistanceCheck(int CustomerId, DateTime IssueDateTime)
        {
            var result =  _context.ElectricBills.Where(p => p.CustomerId == CustomerId && p.IssueDate.Value.Month == IssueDateTime.Month && p.IssueDate.Value.Year == IssueDateTime.Year).FirstOrDefault();
           
            return result!=null?true:false;
        }
    }
}
