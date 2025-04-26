namespace TCMApp.Server.Core.Interfaces
{
    public interface IMapper<TSource, TDestination>
        where TSource : class
        where TDestination : class
    {
        public TDestination Map(TSource source);
    }
}
