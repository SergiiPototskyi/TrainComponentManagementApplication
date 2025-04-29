using TCMApp.Core.Specifications;

namespace TCMApp.Core.Interfaces
{
    public interface ICollectionQuery<T> where T : class
    {
        public IReadOnlyCollection<T> GetCollection(Specification<T> specification);
    }
}