using System;
using WP7.CalculateExpressions.Expressions;

namespace WP7.CalculateExpressions.Operations
{
	public class LabdaUnaryOperation : UnaryOperation
	{
		private readonly Func<double,  double> _func;

		public LabdaUnaryOperation(Func<double,  double> func, IExpression exp)
			: base(exp)
		{
			_func = func;
		}

		public override double Value
		{
			get { return _func(Ex.Value); }
		}
	}
}