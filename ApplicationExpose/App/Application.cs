using ApplicationExpose.IApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN.IServiceBase;

namespace ApplicationExpose.App
{
    public class Application<TEntity> : IApplication<TEntity> where TEntity : class
    {
        private readonly IService<TEntity> _service;
        public Application(IService<TEntity> service)
        {
            _service = service;
        }

        public void Add(TEntity entity)
        {
            _service.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _service.Delete(entity);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public List<TEntity> GetAllList()
        {
            return _service.GetAllList();
        }

        public IEnumerable<TEntity> GetList()
        {
            return _service.GetList();
        }

        public void Update(TEntity entity)
        {
            _service.Update(entity);
        }
    }
}
