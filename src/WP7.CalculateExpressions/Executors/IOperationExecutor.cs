using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.Executors
{
    public interface IOperationExecutor
    {
        IOperation GetOperation(string expression);
    }
}