using TCMApp.Server.Data.Specifications;

namespace TCMApp.Server.Core.Interfaces;

public interface ICollectionQuery<T> where T : class
{
    public IReadOnlyCollection<T> GetCollection(Specification<T> specification);
}