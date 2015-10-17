using System;
using System.Globalization;
using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Expressions;
using WP7.Calculator.ViewModel.Expressions;

namespace WP7.Calculator.ViewModel.Commands
{
	public class ExecuteExpressionCommand: CalculatorCommand
	{
		public ExecuteExpressionCommand(MainViewModel target)
			: base(target)
		{
			
		}

		public override void Execute(object parameter)
		{
			try
			{
				var oex = new OperationExecutor(new CalculatorOperationRecognizerProvider());
                var ex = Expression.Create(string.IsNullOrEmpty(_target.CalculatorExpression) ? "0" : _target.CalculatorExpression, oex);
				_target.CalculatorResult = Math.Round(ex.Value, 10).ToString(CultureInfo.InvariantCulture);
			}
			catch(Exception ex)
			{
				_target.CalculatorResult = string.Format("Expression '{0}' not suported", ex.Message);
			}
		}
	}
}