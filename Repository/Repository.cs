using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FoodDelivery.Core;
using FoodDelivery.Dtos;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

		public readonly DbContext _context;

		public Context context
		{
			get { return _context as Context; }
		}

        public void Add(TEntity entity)
        {
			_context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Detach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity SignelOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
