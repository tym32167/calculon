using System;
using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Expressions;
using WP7.CalculateExpressions.OperationProviders;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.Recognizers
{
    /// <summary>
    /// Класс работает с простыми бинарными операциями (такими как + ,- , *, /)
    /// Для работы с классом (для создания простого бинарного рекогнайзера) достаточно переопределить символ операции и возвращаемую операцию.
    /// </summary>
    public class BinaryOperationRecognizer : IOperationRecognizer
    {
    	private readonly string _operationSymbol;
    	private readonly IBinaryOperationProvider _binaryOperationProvider;
    	private Expression _ex1;
        private Expression _ex2;

		public BinaryOperationRecognizer(string operationSymbol, IBinaryOperationProvider binaryOperationProvider)
		{
			_operationSymbol = operationSymbol;
			_binaryOperationProvider = binaryOperationProvider;
		}

    	#region Implementation of IOperationRecognizer

        public IOperation Recognize(string expression, IOperationExecutor operationExecutor)
        {
            var si = Index(expression, operationExecutor);
        	var check = false;

            if (si >= 0)
            {
                var sop1 = expression.Substring(0, si);
                var sop2 = expression.Substring(si + 1, expression.Length - si - 1);

            	check = CheckOperation(sop1, sop2, operationExecutor);
                if (check)
                {
					return _binaryOperationProvider.GetOperation(_ex1, _ex2);
                }
            }
        	throw new NotSupportedException(expression);
        }

        public int Index(string expression, IOperationExecutor operationExecutor)
        {
            var maxIndex = -1;
            for (var i = 0; i < expression.Length; i++)
            {
                var ind = expression.IndexOf(_operationSymbol, i);
                if (ind > maxIndex && (ind + _operationSymbol.Length) <= (expression.Length-1))
                {
                    var sop1 = expression.Substring(0, ind);
                    var sop2 = expression.Substring(ind + _operationSymbol.Length, expression.Length - ind -_operationSymbol.Length);

                    if (CheckOperation(sop1, sop2, operationExecutor))
                    {
                        maxIndex = ind;
                    }
                }
            }
            return maxIndex;
        }


        private bool CheckOperation(string op1, string op2, IOperationExecutor operationExecutor)
        {
			_ex1 = Expression.Create(op1, operationExecutor);
            if (!_ex1.HasValue) return false;
			_ex2 = Expression.Create(op2, operationExecutor);
			return (_ex2.HasValue);
        }


        #endregion
    }
}
