using System;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.OperationProviders
{
	public class LambdaUnaryOperationProvider: IUnaryOperationProvider
	{
		private readonly Func<double, double> _func;

		public LambdaUnaryOperationProvider(Func<double, double> func)
		{
			_func = func;
		}

		public IOperation GetOperation(IExpression exp)
		{
			return new LabdaUnaryOperation(_func, exp);
		}
	}
}