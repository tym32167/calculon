using System.Collections.Generic;
using WP7.CalculateExpressions.Recognizers;

namespace WP7.CalculateExpressions.RecognizerProviders
{
    public interface IOperationRecognizerProvider
    {
        IEnumerable<IEnumerable<IOperationRecognizer>> GetRecognizers();
    }
}
