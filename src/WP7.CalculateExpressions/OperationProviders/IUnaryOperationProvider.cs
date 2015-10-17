using System;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.OperationProviders
{
	public interface IUnaryOperationProvider
	{
		IOperation GetOperation(IExpression exp);
	}
}