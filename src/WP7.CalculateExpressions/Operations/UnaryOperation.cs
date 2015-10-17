using WP7.CalculateExpressions.Expressions;

namespace WP7.CalculateExpressions.Operations
{
    public abstract class UnaryOperation : IOperation
    {
        protected readonly IExpression Ex;

        protected UnaryOperation(IExpression ex)
        {
            Ex = ex;
        }

        #region Implementation of IOperation

		public abstract double Value { get; }

        #endregion
    }
}