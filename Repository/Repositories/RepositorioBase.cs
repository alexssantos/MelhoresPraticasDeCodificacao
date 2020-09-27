using Domain.Cliente.Aggregate.Respositories;
using Domain.Shared;
using Domain.Specification;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
	public class RepositorioBase<T> : IRepositorioBase<T> where T : Entity
	{

		private DbSet<T> Query { get; set; }
		private BankContext Context { get; set; }

		public RepositorioBase(BankContext context)
		{
			this.Context = context;
			this.Query = context.Set<T>();
		}


		public void Delete(Guid id)
		{
			var entity = Query.Find(id);
			Query.Remove(entity);
			this.Context.SaveChanges();
		}

		public IList<T> GetAll()
		{
			return Query.ToList();
		}

		public T GetById(Guid id)
		{
			return Query.Find(id);
		}

		public void Save(T entity)
		{
			Query.Add(entity);
			this.Context.SaveChanges();
		}

		public void Update(Guid id, T entity)
		{
			this.Query.Update(entity);
			this.Context.Entry(entity).State = EntityState.Modified;
			this.Context.SaveChanges();
		}

		public IList<T> GetAllByCriteria(ISpecification<T> expr)
		{
			var result = Query.Where(expr.SatisfyByCriteria()).ToArray();
			return result;
		}

		public T GetOneByCriteria(ISpecification<T> expr)
		{
			var result = Query.FirstOrDefault(expr.SatisfyByCriteria());
			return result;
		}
	}
}
