﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.IRepository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetList();
        List<TEntity> GetAllList();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);


    }
}
