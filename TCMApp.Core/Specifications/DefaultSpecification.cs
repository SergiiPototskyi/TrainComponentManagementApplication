using System.Linq.Expressions;

namespace TCMApp.Core.Specifications
{
    public class DefaultSpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return _ => true; // Always return true for all entities
        }
    }
}
