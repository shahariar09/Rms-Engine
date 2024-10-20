using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Rms.BLL.Abstraction.Base;
using Rms.Models.Common;
using Rms.Models.Common.Paging;
using Rms.Repo.Abstraction.Base;



namespace Rms.BLL.Base
{
    public abstract class Manager<T> : IManager<T> where T : class
    {
        private readonly IRepository<T> _repository;
        //private IClassroomPackageRepository repo;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }
        public virtual async Task<bool> RemoveAsync(T entity)
        {
            return await _repository.RemoveAsync(entity);
        }



        public void Dispose()
        {

        }

        public virtual async Task<Result> Add(T entity)
        {
            bool isAdded = await _repository.Add(entity);

            if (isAdded)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<Result> Update(T entity)
        {
            bool isUpdate = await _repository.Update(entity);

            if (isUpdate)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to update data!" });
        }

        public virtual async Task<Result> Remove(long id)
        {
            var data = await _repository.GetById(id);

            if (data != null)
            {
                bool isRemove = await _repository.Remove(data);
                if (isRemove)
                {
                    return Result.Success();
                }
            }
            return Result.Failure(new[] { "Unable to remove" });
        }
        public virtual async Task<Result> Remove(int id)
        {
            var data = await _repository.GetById(id);

            if (data != null)
            {
                bool isRemove = await _repository.Remove(data);
                if (isRemove)
                {
                    return Result.Success();
                }
            }
            return Result.Failure(new[] { "Unable to remove" });
        }
        public async virtual Task<ICollection<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(long id)
        {
            return await _repository.GetById(id);
        }
        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<T> GetFirstorDefault(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetFirstorDefault(predicate);
        }

        public virtual async Task<Result> AddRangeAsync(ICollection<T> entities)
        {

            bool isAdded = await _repository.AddRangeAsync(entities);

            if (isAdded)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });

            
        }

        public async Task<Result> UpdateRangeAsync(ICollection<T> entity)
        {
            bool isAdded = await _repository.UpdateRangeAsync(entity);

            if (isAdded)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }

      
    }
}
