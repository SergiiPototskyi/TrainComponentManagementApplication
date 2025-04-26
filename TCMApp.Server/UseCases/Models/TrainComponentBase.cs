namespace TCMApp.Server.UseCases.Models
{
    public abstract record TrainComponentBase
    {
        public required string Name { get; set; }
        public required string UniqueNumber { get; set; }
        public bool CanAssignQuantity { get; set; }
        public int? Quantity { get; set; }
    }
}