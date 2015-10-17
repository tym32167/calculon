using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.OperationProviders
{
	public interface IBinaryOperationProvider
	{
		IOperation GetOperation(IExpression exp1, IExpression exp2);
	}
}