namespace TCMApp.Server.UseCases.Models
{
    public record TrainComponentResponse : TrainComponentBase
    {
        public int Id { get; init; }
    }
}
