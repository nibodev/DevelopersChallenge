using DOMAIN.IServiceBase;
using DOMAIN.Entities;
using DOMAIN.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.ServiceBase
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repostory;
        public Service(IRepositoryBase<TEntity> repository)
        {
            _repostory = repository;
        }

        public void Add(TEntity entity)
        {
            _repostory.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _repostory.Delete(entity);
        }

        public void Dispose()
        {
            _repostory.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repostory.GetAll();
        }

        public List<TEntity> GetAllList()
        {
            return _repostory.GetAllList();
        }

        public IEnumerable<TEntity> GetList()
        {
            return _repostory.GetList();
        }

        public void Update(TEntity entity)
        {
            _repostory.Update(entity);
        }
    }
}
