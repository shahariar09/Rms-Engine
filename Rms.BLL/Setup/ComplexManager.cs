using Rms.BLL.Abstraction.Setup;
using Rms.BLL.Base;
using Rms.Models.Common;
using Rms.Models.Common.Paging;
using Rms.Models.CriteriaDto.Setup;
using Rms.Models.Entities.Setup;
using Rms.Repo.Abstraction.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.BLL.Setup
{
    public class ComplexManager : Manager<Complex>, IComplexManager
    {
        private readonly IComplexRepository _customerRepository;

        public ComplexManager(IComplexRepository ComplexRepository) : base(ComplexRepository)
        {
            _customerRepository = ComplexRepository;
        }

        public virtual async Task<Result> Add(Complex customer)
        {
            bool isAdded = await _customerRepository.Add(customer);

            if (isAdded)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }

        public async Task<PagedList<Complex>> GetByCriteria(ComplexCriteriaDto criteriaDto)
        {
            var data = _customerRepository.GetByCriteria(criteriaDto);

            if (criteriaDto != null)
            {
                var result = await PagedList<Complex>.CreateAsync(data, criteriaDto.PageParams.PageNumber, criteriaDto.PageParams.PageSize);
                return result;
            }
            else
            {
                var totalDataCount = data.Count();

                return new PagedList<Complex>(data.ToList(), data.Count(), 1, totalDataCount);
            }
        }
    }
}
