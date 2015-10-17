namespace WP7.Calculator.ViewModel.Commands
{
	public class RemoveLastCharCommand : CalculatorCommand
	{
		public RemoveLastCharCommand(MainViewModel target) : base(target)
		{
			
		}
		
		public override void Execute(object parameter)
		{
			if (!string.IsNullOrEmpty(_target.CalculatorExpression))
			_target.CalculatorExpression = _target.CalculatorExpression.Substring(0, _target.CalculatorExpression.Length - 1);
		}
	}
}