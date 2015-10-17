using System.Windows.Input;
using GalaSoft.MvvmLight;
using WP7.Calculator.ViewModel.Commands;

namespace WP7.Calculator.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			AddToTextCommand = new AddToTextCommand(this);
			RemoveLastCharCommand = new RemoveLastCharCommand(this);
			ClearCommand = new ClearCommand(this);
			ExecuteExpressionCommand = new ExecuteExpressionCommand(this);
			CalculatorResult = " ";
		}

		public ICommand AddToTextCommand { get; set; }
		public ICommand RemoveLastCharCommand { get; set; }
		public ICommand ClearCommand { get; set; }
		public ICommand ExecuteExpressionCommand { get; set; }

		
		private string _calculatorExpression;
		public string CalculatorExpression
		{
			get
			{
				return _calculatorExpression;
			}
			set
			{
				if (_calculatorExpression != value)
				{
					_calculatorExpression = value;
					RaisePropertyChanged("CalculatorExpression");
				}
			}
		}


		private string _calculatorResult;
		public string CalculatorResult
		{
			get
			{
				return _calculatorResult;
			}
			set
			{
				if (_calculatorResult != value)
				{
					_calculatorResult = value;
					RaisePropertyChanged("CalculatorResult");
				}
			}
		}
	}
}