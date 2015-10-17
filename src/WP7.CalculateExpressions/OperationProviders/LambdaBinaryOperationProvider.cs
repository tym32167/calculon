using System;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.OperationProviders
{
	public class LambdaBinaryOperationProvider : IBinaryOperationProvider
	{
		private readonly Func<double, double, double> _func;

		public LambdaBinaryOperationProvider(Func<double, double, double> func)
		{
			_func = func;
		}

		public IOperation GetOperation(IExpression exp1, IExpression exp2)
		{
			return new LabdaBinaryOperation(_func, exp1, exp2);
		}
	}
}