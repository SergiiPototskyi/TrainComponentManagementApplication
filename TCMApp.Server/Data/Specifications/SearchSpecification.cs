using System.Linq.Expressions;
using TCMApp.Server.Core.Entities;

namespace TCMApp.Server.Data.Specifications
{
    public class SearchSpecification(string? searchTerm) : Specification<TrainComponent>
    {
        public override Expression<Func<TrainComponent, bool>> ToExpression()
        {
            return x => searchTerm == null || x.Name.Contains(searchTerm) || x.UniqueNumber.Contains(searchTerm);
        }
    }
}
