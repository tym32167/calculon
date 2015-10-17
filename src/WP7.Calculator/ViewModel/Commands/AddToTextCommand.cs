using System;

namespace WP7.Calculator.ViewModel.Commands
{
	public class AddToTextCommand : CalculatorCommand
	{
		public AddToTextCommand(MainViewModel target) : base(target)
		{
			
		}
		
		public override void Execute(object parameter)
		{
			var str = parameter as String;
			if (!string.IsNullOrEmpty(str))
			{
				_target.CalculatorExpression += str;
			}
		}
	}
}