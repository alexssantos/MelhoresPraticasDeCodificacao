using Domain.Specification.Conditions;
using System;
using System.Linq.Expressions;

namespace Domain.Specification
{
	public class Specification<T> : ISpecification<T>
	{

		public Expression<Func<T, bool>> Criteria { get; private set; }

		public Specification(Expression<Func<T, bool>> criteria)
		{
			Criteria = criteria;
		}

		public Specification()
		{

		}

		public virtual Expression<Func<T, bool>> SatisfyByCriteria()
		{
			return this.Criteria;
		}

		public Specification<T> And(ISpecification<T> specification)
		{
			this.Criteria = new AndSpecification<T>(this, specification as Specification<T>).SatisfyByCriteria();
			return this;
		}

		public Specification<T> Or(ISpecification<T> specification)
		{
			this.Criteria = new OrSpecification<T>(this, specification as Specification<T>).SatisfyByCriteria();
			return this;
		}

		public bool IsSatisfiedBy(T entity)
		{
			return this.Criteria.Compile().Invoke(entity);
		}
	}
}
