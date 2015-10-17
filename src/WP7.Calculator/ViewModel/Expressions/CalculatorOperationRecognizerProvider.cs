using System;
using System.Collections.Generic;
using WP7.CalculateExpressions.OperationProviders;
using WP7.CalculateExpressions.RecognizerProviders;
using WP7.CalculateExpressions.Recognizers;

namespace WP7.Calculator.ViewModel.Expressions
{
	public class CalculatorOperationRecognizerProvider : IOperationRecognizerProvider
	{
		#region Implementation of IOperationRecognizerProvider

		/// <summary>
		/// тут находятся рекогнайзеры операций в обратном порядке приоритета. 
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IEnumerable<IOperationRecognizer>> GetRecognizers()
		{
			return new List<IEnumerable<IOperationRecognizer>>
			       	{
			       		new List<IOperationRecognizer>
			       			{
			       				new BinaryOperationRecognizer(
									"+", 
									new LambdaBinaryOperationProvider((x, y) => x + y)),
			       				new BinaryOperationRecognizer(
									"-", 
									new LambdaBinaryOperationProvider((x, y) => x - y))
			       			},

			       		new List<IOperationRecognizer>
			       			{
			       				new BinaryOperationRecognizer(
									"*",
									new LambdaBinaryOperationProvider((x, y) => x*y)),
			       				new BinaryOperationRecognizer(
									"/", 
									new LambdaBinaryOperationProvider((x, y) => x/y)),
			       			},


			       		new List<IOperationRecognizer>
			       			{
			       				new BinaryOperationRecognizer(
									"^", 
									new LambdaBinaryOperationProvider(Math.Pow)),
			       			},


			       		new List<IOperationRecognizer>
			       			{
			       				new UnaryFunctionRecognizer(
									"sin",
									new LambdaUnaryOperationProvider(Math.Sin)),
			       				new UnaryFunctionRecognizer(
									"cos", 
									new LambdaUnaryOperationProvider(Math.Cos)),
			       				new UnaryFunctionRecognizer(
									"tan", 
									new LambdaUnaryOperationProvider(Math.Tan)),
			       				new UnaryFunctionRecognizer(
									"ctan", 
									new LambdaUnaryOperationProvider(x => 1/Math.Tan(x))),


			       				new UnaryFunctionRecognizer(
									"asin", 
									new LambdaUnaryOperationProvider(Math.Asin)),
			       				new UnaryFunctionRecognizer(
									"acos", 
									new LambdaUnaryOperationProvider(Math.Acos)),
			       				new UnaryFunctionRecognizer(
									"atan", 
									new LambdaUnaryOperationProvider(Math.Atan)),
			       				new UnaryFunctionRecognizer(
									"actan", 
									new LambdaUnaryOperationProvider(x => (Math.PI*0.5) - Math.Atan(x))),

			       				new UnaryFunctionRecognizer(
									"abs", 
									new LambdaUnaryOperationProvider(Math.Abs)),

			       				new UnaryFunctionRecognizer(
									"sqrt", 
									new LambdaUnaryOperationProvider(Math.Sqrt)),
			       			},

			       		new List<IOperationRecognizer>
			       			{
			       				new BracketsOperationRecognizer(
									new LambdaUnaryOperationProvider(x => x)),
			       				new AbsoluteBracketsOperationRecognizer(
									new LambdaUnaryOperationProvider(Math.Abs))
			       			},

			       		new List<IOperationRecognizer>
			       			{
			       				new ConstantRecognizer(
									"pi", 
									Math.PI, 
									new NumberOperationProvider()),
			       				new ConstantRecognizer(
									"e", 
									Math.E, 
									new NumberOperationProvider())
			       			},

			       		new List<IOperationRecognizer>
			       			{
			       				new NumberOperationRecognizer(
									new NumberOperationProvider())
			       			},

			       	};
		}

		#endregion
	}
}
