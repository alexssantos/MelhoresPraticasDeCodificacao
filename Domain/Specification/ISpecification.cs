using System;
using System.Linq.Expressions;

namespace Domain.Specification
{
	public interface ISpecification<T>
	{
		bool IsSatisfiedBy(T entity);
		Expression<Func<T, bool>> SatisfyByCriteria();
		Specification<T> And(ISpecification<T> specification);
		Specification<T> Or(ISpecification<T> specification);
	}
}
