using System.Text.RegularExpressions;
using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.OperationProviders;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.Recognizers
{
	public class UnaryFunctionRecognizer : IOperationRecognizer
	{
		private readonly string _functionName;
		private readonly IUnaryOperationProvider _unaryOperationProvider;

		public UnaryFunctionRecognizer (string functionName, IUnaryOperationProvider unaryOperationProvider)
		{
			_functionName = functionName;
			_unaryOperationProvider = unaryOperationProvider;
		}

		public IOperation Recognize(string expression, IOperationExecutor operationExecutor)
		{
			if (Index(expression, operationExecutor) == 0)
			{
				var len = _functionName.Length;
				var nExp = expression.Substring(1 + len, expression.Length - 2 - len);
				var bo = _unaryOperationProvider.GetOperation(Expression.Create(nExp, operationExecutor));
				return bo;
			}
			return null;
		}

		public int Index(string expression, IOperationExecutor operationExecutor)
		{
			var rx = new Regex(@"^" +_functionName+ @"\(.*\)$");
			var result =  rx.IsMatch(expression) ? 0 : -1;
			return result;
		}
	}
}