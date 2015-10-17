using System;
using WP7.CalculateExpressions.Expressions;

namespace WP7.CalculateExpressions.Operations
{
	public class LabdaBinaryOperation : BinaryOperation
	{
		private readonly Func<double, double, double> _func;

		public LabdaBinaryOperation(Func<double, double, double> func, IExpression exp1, IExpression exp2) : base(exp1, exp2)
		{
			_func = func;
		}

		public override double Value
		{
			get { return _func(Ex1.Value, Ex2.Value); }
		}
	}
}