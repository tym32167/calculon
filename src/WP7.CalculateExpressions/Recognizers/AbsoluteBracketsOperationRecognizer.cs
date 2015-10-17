using System.Text.RegularExpressions;
using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.OperationProviders;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.Recognizers
{
    public class AbsoluteBracketsOperationRecognizer : IOperationRecognizer
    {
    	private readonly IUnaryOperationProvider _operationProvider;

    	#region Implementation of IOperationRecognizer

		public AbsoluteBracketsOperationRecognizer(IUnaryOperationProvider operationProvider)
		{
			_operationProvider = operationProvider;
		}

    	public IOperation Recognize(string expression, IOperationExecutor operationExecutor)
        {
            if (Index(expression, operationExecutor) == 0)
            {
                var nExp = expression.Substring(1, expression.Length - 2);
				var bo = _operationProvider.GetOperation(Expression.Create(nExp, operationExecutor));
                return bo;
            }
            return null;
        }

        public int Index(string expression, IOperationExecutor operationExecutor)
        {
            var rx = new Regex(@"^\|.*\|$");
            return rx.IsMatch(expression) ? 0 : -1;
        }

        #endregion
    }
}
