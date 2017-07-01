
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using INFRA.Context;
using System.Runtime.Remoting.Contexts;
using DOMAIN.IRepository;

namespace INFRA.Repository
{
    public abstract class RepositoryBase<TEntity> :  IRepositoryBase<TEntity> where TEntity : class
    {

        DBContext<TEntity> context = new DBContext<TEntity>();
        public void Add(TEntity entity)
        {


            context.Set<TEntity>().Add(entity);
            context.Database.Log = log => System.Diagnostics.Debug.WriteLine(log);
            context.SaveChanges();
          
        }

        public void Delete(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.Database.Log = log => System.Diagnostics.Debug.WriteLine(log);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

          
            //context.SaveChanges();
        }

        public void Dispose()
        {
            
        }
       
        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();
            return query;
        }

        public List<TEntity> GetAllList()
        {
            return context.Set<TEntity>().AsEnumerable().ToList();
        }

        public IEnumerable<TEntity> GetList()
        {
            return context.Set<TEntity>().AsEnumerable().ToList();
        }

        public void Update(TEntity entity)
        {

            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.Database.Log = log => System.Diagnostics.Debug.WriteLine(log);
            context.SaveChanges();
            //context.SaveChanges();
        }
    }
}
