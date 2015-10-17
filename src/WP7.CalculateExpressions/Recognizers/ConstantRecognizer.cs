using System;
using System.Globalization;
using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.OperationProviders;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.Recognizers
{
	public class ConstantRecognizer:IOperationRecognizer
	{
		private readonly string _constString;
		private readonly double _constValue;
		private readonly IUnaryOperationProvider _unaryOperationPrvider;

		public ConstantRecognizer(string constString, double constValue, IUnaryOperationProvider unaryOperationPrvider)
		{
			_constString = constString;
			_constValue = constValue;
			_unaryOperationPrvider = unaryOperationPrvider;
		}

		public IOperation Recognize(string expression, IOperationExecutor operationExecutor)
		{
			if (expression == _constString)
				return
					_unaryOperationPrvider.GetOperation(Expression.Create(_constValue.ToString(CultureInfo.InvariantCulture),
					                                                      operationExecutor));
			throw new NotSupportedException(expression);
		}

		public int Index(string expression, IOperationExecutor operationExecutor)
		{
			return expression == _constString ? 0 : -1;
		}
	}
}