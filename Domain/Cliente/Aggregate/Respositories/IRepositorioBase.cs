using Domain.Specification;
using System;
using System.Collections.Generic;

namespace Domain.Cliente.Aggregate.Respositories
{
	public interface IRepositorioBase<T> where T : Shared.Entity
	{
		public IList<T> GetAll();
		public T GetById(Guid id);
		public void Save(T obj);
		public void Update(Guid id, T obj);
		public void Delete(Guid id);

		//T GetOneByCriteria(Expression<Func<T, bool>><T> expr);
		T GetOneByCriteria(ISpecification<T> expr);
		//IList<T> GetAllByCriteria(Expression<Func<T, bool>><T> expr);
		IList<T> GetAllByCriteria(ISpecification<T> expr);
	}
}
