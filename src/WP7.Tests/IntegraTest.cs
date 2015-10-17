using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.OperationProviders;
using WP7.CalculateExpressions.RecognizerProviders;
using WP7.CalculateExpressions.Recognizers;

namespace WP7.Tests
{
	[TestClass]
	public class IntegraTest
	{
		[TestMethod]
		public void Test1()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var ex = Expression.Create("1+2", oex);
			Assert.AreEqual(3, ex.Value);

			ex = Expression.Create("1+2+3+4+5+6+7", oex);
			Assert.AreEqual(28, ex.Value);
		}

		[TestMethod]
		public void Test2()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var ex = Expression.Create("1+2+(3+4)", oex);
			Assert.AreEqual(10, ex.Value);
		}

		[TestMethod]
		public void Test3()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var ex = Expression.Create("1+2*2+(3+4*4)*2", oex);
			Assert.AreEqual(43, ex.Value);
		}

		[TestMethod]
		public void Test4()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var ex = Expression.Create("(3+4)", oex);
			Assert.AreEqual(7, ex.Value);
		}

		[TestMethod]
		public void Test5()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var ex = Expression.Create("1+9-3*(43+2)-|-9|+3", oex);
			Assert.AreEqual(-131, ex.Value);
		}


		[TestMethod]
		public void Test6()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var ex = Expression.Create("1+9-3*(43+2)-9+3", oex);
			Assert.AreEqual(-131, ex.Value);
		}


		[TestMethod]
		public void Test7()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var sub = new BinaryOperationRecognizer("-", new LambdaBinaryOperationProvider((x, y) => x - y));
			var add = new BinaryOperationRecognizer("+", new LambdaBinaryOperationProvider((x, y) => x + y));

			var index = sub.Index("135-9+3", oex);
			Assert.AreEqual(3, index);

			index = add.Index("135-9+3", oex);
			Assert.AreEqual(5, index);

			var ex = Expression.Create("1+9-3*(43+2)-9+3", oex);
			Assert.AreEqual(-131, ex.Value);
		}


		[TestMethod]
		public void Test8()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var ex = Expression.Create("135-9+3", oex);
			Assert.AreEqual(129, ex.Value);
		}

		[TestMethod]
		public void Test9()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());
			var ab = new AbsoluteBracketsOperationRecognizer(new LambdaUnaryOperationProvider(Math.Abs));


			var op = ab.Recognize("|-9|", oex);
			Assert.AreEqual(9, op.Value);

			var sub = new BinaryOperationRecognizer("-", new LambdaBinaryOperationProvider((x, y) => x - y));
			var ind = sub.Index("|-9|", oex);
			Assert.AreEqual(-1, ind);
		}

		[TestMethod]
		public void Test10()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());

			var ex = Expression.Create("3*(43+2)-|-9|", oex);
			Assert.AreEqual(126, ex.Value);


		}


		[TestMethod]
		public void Test11()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());

			var ex = Expression.Create("3*(43+2)-|-9|/3", oex);
			
			Assert.AreEqual(132, ex.Value);
		}

		[TestMethod]
		public void Test12()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());

			var ex = Expression.Create("pi", oex);
			Assert.AreEqual(Math.PI.ToString(), ex.Value.ToString());
		}



		[TestMethod]
		public void Test13()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());

			var ex = Expression.Create("sin(pi/2)+1+e", oex);
			Assert.AreEqual((Math.Sin(Math.PI / 2d) + 1d + Math.E).ToString().Substring(0, 10), ex.Value.ToString().Substring(0, 10));
		}


		[TestMethod]
		public void Test14()
		{
			var oex = new OperationExecutor(new OperationRecognizerProvider());

			var ex = Expression.Create("3.5+4^(1+2)", oex);
			Assert.AreEqual(67.5, ex.Value);
		}
	}
}
