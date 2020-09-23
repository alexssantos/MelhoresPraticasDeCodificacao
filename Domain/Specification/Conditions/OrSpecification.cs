using System;
using System.Linq.Expressions;

namespace Domain.Specification.Conditions
{
	public class OrSpecification<T> : Specification<T>, ISpecification<T>
	{
		private readonly Specification<T> _esquerdo;
		private readonly Specification<T> _direito;

		public OrSpecification(Expression<Func<T, bool>> expression) : base(expression)
		{

		}

		public OrSpecification(Specification<T> esquerdo, Specification<T> direito)
		{
			_esquerdo = esquerdo;
			_direito = direito;
		}

		public override Expression<Func<T, bool>> SatisfyByCriteria()
		{
			Expression<Func<T, bool>> expressEsquerda = _esquerdo.Criteria;
			Expression<Func<T, bool>> expressDireita = _direito.Criteria;

			var paramExpr = Expression.Parameter(typeof(T));

			var exprBody = Expression.OrElse(expressEsquerda.Body, expressDireita.Body);
			exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
			var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

			return finalExpr;
		}
	}
}
