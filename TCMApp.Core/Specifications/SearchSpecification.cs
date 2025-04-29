using System.Linq.Expressions;
using TCMApp.Core.Entities;

namespace TCMApp.Core.Specifications
{
    public class SearchSpecification(string? searchTerm) : Specification<TrainComponent>
    {
        public override Expression<Func<TrainComponent, bool>> ToExpression()
        {
            return x => searchTerm == null || x.Name.Contains(searchTerm) || x.UniqueNumber.Contains(searchTerm);
        }
    }
}
