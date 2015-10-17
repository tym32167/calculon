using System;
using System.Globalization;
using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.OperationProviders;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.Recognizers
{
    public class NumberOperationRecognizer : IOperationRecognizer
    {
    	private readonly IUnaryOperationProvider _operationProvider;

		public NumberOperationRecognizer(IUnaryOperationProvider operationProvider)
		{
			_operationProvider = operationProvider;
		}

        #region Implementation of IOperationRecognizer

        public IOperation Recognize(string expression, IOperationExecutor operationExecutor)
        {
        	var exp = Expression.Create(expression, operationExecutor);
        	return _operationProvider.GetOperation(exp);
        }

        public int Index(string expression, IOperationExecutor operationExecutor)
        {
            if (CheckOperation(expression))
            {
                return 0;
            }

            return -1;
        }


        private static bool CheckOperation(string op)
        {
            double result;
			return Double.TryParse(op, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }


        #endregion
    }
}
