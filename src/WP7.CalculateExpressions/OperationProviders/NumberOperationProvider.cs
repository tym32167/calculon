using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.OperationProviders
{
	public class NumberOperationProvider:IUnaryOperationProvider
	{
		public IOperation GetOperation(IExpression exp)
		{
			return new NumberOperation(exp);
		}
	}
}