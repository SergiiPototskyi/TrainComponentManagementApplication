using System.Linq.Expressions;

namespace TCMApp.Server.Data.Specifications
{
    public class DefaultSpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return _ => true; // Always return true for all entities
        }
    }
}
