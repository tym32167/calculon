using WP7.CalculateExpressions.Executors;
using WP7.CalculateExpressions.Operations;

namespace WP7.CalculateExpressions.Recognizers
{
    public interface IOperationRecognizer
    {
        IOperation Recognize(string expression, IOperationExecutor operationExecutor);
        int Index(string expression, IOperationExecutor operationExecutor);
    }
}
