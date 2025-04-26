namespace TCMApp.Server.Core.Interfaces
{
    public interface IQuery<T> where T : class
    {
        public Task<T> GetAsync(Guid id, CancellationToken cancellationToken);
    }
}