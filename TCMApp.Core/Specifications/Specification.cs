using System.Linq.Expressions;

namespace TCMApp.Core.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And(Specification<T> other)
        {
            var thisExpression = ToExpression();
            var otherExpression = other.ToExpression();
            var parameter = Expression.Parameter(typeof(T));

            var combinedExpression = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    Expression.Invoke(thisExpression, parameter),
                    Expression.Invoke(otherExpression, parameter)
                ),
                parameter);

            return new ExpressionSpecification<T>(combinedExpression);
        }

        // You can add Or, Not, etc., similarly.
    }

    public class ExpressionSpecification<T> : Specification<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        public ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            _expression = expression;
        }

        public override Expression<Func<T, bool>> ToExpression() => _expression;
    }
}
