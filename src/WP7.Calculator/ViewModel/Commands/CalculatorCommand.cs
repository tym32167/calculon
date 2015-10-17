using System;
using System.Windows.Input;

namespace WP7.Calculator.ViewModel.Commands
{
	public abstract class CalculatorCommand : ICommand
	{
		 protected MainViewModel _target;

		protected CalculatorCommand(MainViewModel target)
		{
			_target = target;
		}
	
		public bool CanExecute(object parameter)
		{
			return _target != null;
		}

		public abstract void Execute(object parameter);

		public event EventHandler CanExecuteChanged;
	}
}