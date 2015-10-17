namespace WP7.CalculateExpressions.Expressions
{
    public interface IExpression
    {
    	double Value { get; }
    	bool HasValue { get; }
		string StringExpression { get; }
    }
}