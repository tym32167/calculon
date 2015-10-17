namespace WP7.Calculator.ViewModel.Commands
{
	public class ClearCommand : CalculatorCommand
	{
		public ClearCommand(MainViewModel target)
			: base(target)
		{
			
		}

		public override void Execute(object parameter)
		{
			_target.CalculatorExpression = string.Empty;
		}
	}
}