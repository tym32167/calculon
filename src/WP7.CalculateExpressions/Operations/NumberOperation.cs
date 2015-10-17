using System;
using System.Globalization;
using WP7.CalculateExpressions.Expressions;

namespace WP7.CalculateExpressions.Operations
{
    public sealed class NumberOperation : IOperation
    {
        public NumberOperation(IExpression ex)
        {
            Double op;
            if (ex.StringExpression.IndexOf('+') <= 0 && ex.StringExpression.IndexOf('-') <= 0 && Double.TryParse(ex.StringExpression, NumberStyles.Any, CultureInfo.InvariantCulture, out op))
                Value = op;
            else throw new NotSupportedException(ex.StringExpression);
        }



        #region Implementation of IOperation

        public double Value { get; private set; }

        #endregion
    }
}