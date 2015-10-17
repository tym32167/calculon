using WP7.CalculateExpressions.Expressions;

namespace WP7.CalculateExpressions.Operations
{
    public abstract class BinaryOperation : IOperation
    {
        protected readonly IExpression Ex1;
        protected readonly IExpression Ex2;

        protected BinaryOperation(IExpression exp1, IExpression exp2)
        {
            Ex1 = exp1;
            Ex2 = exp2;
        }

        #region Implementation of IOperation

		public abstract double Value { get; }

        #endregion
    }
}