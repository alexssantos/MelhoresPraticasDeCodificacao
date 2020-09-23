using System.Linq.Expressions;

namespace Domain.Specification
{
	//Merge of Expression. 
	//Need to merge/concate expressions like And, Or
	internal class ParameterReplacer : ExpressionVisitor
	{
		private readonly ParameterExpression _parameter;

		protected override Expression VisitParameter(ParameterExpression node) => base.VisitParameter(_parameter);

		internal ParameterReplacer(ParameterExpression parameter)
		{
			_parameter = parameter;
		}
	}
}
