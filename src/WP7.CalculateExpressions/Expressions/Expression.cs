using System;
using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.Expressions
{
    public sealed class Expression : IExpression
    {
        private readonly string _expression;
        private readonly IOperationExecutor _operationExecutor;
    	private IOperation _operation;

    	public static Expression Create(string expression, IOperationExecutor operationExecutor)
		{
			return new Expression(expression, operationExecutor);
		}

        private Expression(string expression, IOperationExecutor operationExecutor)
        {
            _expression = expression;
            _operationExecutor = operationExecutor;
        }

        #region Implementation of IExpression

    	public string StringExpression
    	{
    		get { return _expression; }
    	}

		public double Value
		{
			get
			{
				if (_operation == null) _operation = _operationExecutor.GetOperation(_expression);
				if (_operation == null) throw new NotSupportedException(_expression);
					return _operation.Value;
			}
		}

    	public bool HasValue
    	{
    		get
    		{
				if (_operation == null) _operation = _operationExecutor.GetOperation(_expression);
    			return _operation != null;
    		}
    	}

    	#endregion
    }
}