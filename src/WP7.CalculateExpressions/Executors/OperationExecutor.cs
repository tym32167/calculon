using System.Collections.Generic;
using WP7.CalculateExpressions.Operations;
using WP7.CalculateExpressions.RecognizerProviders;

namespace WP7.CalculateExpressions.Executors
{
    /// <summary>
    /// Класс занимается поиском подходящей операции для выражения.
    /// </summary>
    public class OperationExecutor : IOperationExecutor
    {
        // Это я ввел только для ускорения времени расчета, так как алгоритм перебирает много вариантов решения выражения, он
        // работет долго. Кеширование результатов ускоряет его в разы - это подходит для небольших выражений, но для 
        // больших выражений надо будет уже оптимизировать алгоритм.
        private static readonly Dictionary<string, IOperation> Results = new Dictionary<string, IOperation>();
        private readonly IOperationRecognizerProvider _operationRecognizerProvider;


        public OperationExecutor(IOperationRecognizerProvider operationRecognizerProvider )
        {
            _operationRecognizerProvider = operationRecognizerProvider;
        }

        #region Implementation of IOperationExecutor

        public IOperation GetOperation(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return null;
            if (Results.ContainsKey(expression)) return Results[expression];


            // тут находятся рекогнайзеры операций в обратном порядке приоритета. 
            var recognizerLists = _operationRecognizerProvider.GetRecognizers();


            // Тут происходит поиск подходящей операции. Если поиск завершится неудачей, 
            // значит выражение разобрать невозможно и вернется null
            foreach (var recognizerList in recognizerLists)
            {
                var minIndex = -1;
                IOperation result = null;

                foreach (var operationRecognizer in recognizerList)
                {
                    var index = operationRecognizer.Index(expression, new OperationExecutor(_operationRecognizerProvider));
                    if (index == -1) continue;
                    if (minIndex == -1 || minIndex < index  )
                    {
                        minIndex = index;
                        result = operationRecognizer.Recognize(expression, new OperationExecutor(_operationRecognizerProvider));
                    }
                }

                if (minIndex != -1)
                {
                    // просто кешируем
                    if (Results.Count > 200) Results.Clear();
                    Results.Add(expression, result);
                    
                    return result;
                }
            }

            // просто кешируем
            if (Results.Count > 200) Results.Clear();
            Results.Add(expression, null);

            return null;
        }

        #endregion
    }
}
