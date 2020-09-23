using Domain.Cliente.Aggregate.Respositories;
using Domain.Shared;
using Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
	public class RepositorioBase<T> : IRepositorioBase<T> where T : Entity
	{
		private static List<T> dbEntity = new List<T>();

		public void Delete(Guid id)
		{
			dbEntity.RemoveAll(x => x.Id == id);
		}

		public IList<T> GetAll()
		{
			return dbEntity;
		}

		public T GetById(Guid id)
		{
			return dbEntity.Find(x => x.Id == id);
		}

		public void Save(T entity)
		{
			dbEntity.Add(entity);
		}

		public void Update(Guid id, T entity)
		{
			dbEntity.Where(x => x.Id == id).Select(old => old = entity);
		}

		public IList<T> GetAllByCriteria(ISpecification<T> expr)
		{
			var result = dbEntity.AsQueryable().Where(expr.SatisfyByCriteria()).ToArray();
			return result;
		}

		public T GetOneByCriteria(ISpecification<T> expr)
		{
			var result = dbEntity.AsQueryable().FirstOrDefault(expr.SatisfyByCriteria());
			return result;
		}
	}
}
