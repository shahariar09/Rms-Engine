using Microsoft.EntityFrameworkCore;
using Rms.Database.Database;
using Rms.Models.Common.Paging;
using Rms.Models.CriteriaDto.Setup;
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
    public class ComplexRepository:Repository<Complex>, IComplexRepository
    {
        private readonly ApplicationDbContext _context;

        public ComplexRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<bool> Add(Complex customer)
        {
            _context.Add(customer);

            return await _context.SaveChangesAsync() > 0;
        }

    
        public IQueryable<Complex> GetByCriteria(ComplexCriteriaDto criteriaDto)
        {
            var data = _context.Complexs.Include(c=>c.Users).AsQueryable();



            if (!string.IsNullOrEmpty(criteriaDto.Name))
            {
                data = data.Where(c => c.Name.Contains(criteriaDto.Name.Replace("--", " ").Trim()));
            }
           
            if (criteriaDto.UserId != null)
            {
                data = data.Where(c => c.UserId == criteriaDto.UserId);
            }



            if (criteriaDto.PageParams != null)
            {
                if (!string.IsNullOrWhiteSpace(criteriaDto.PageParams.SearchKey))
                {
                    string searchKey = criteriaDto.PageParams.SearchKey.Replace("--", " ").Trim().ToLower();
                    data = data.Where(c => c.Name.ToLower().Contains(searchKey)

                    );
                }
            }

            return data.OrderBy(c => c.Id);
        }
    }
}
