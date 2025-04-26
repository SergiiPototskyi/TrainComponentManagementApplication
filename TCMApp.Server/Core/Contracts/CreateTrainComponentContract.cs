namespace TCMApp.Server.Core.Contracts
{
    public class CreateTrainComponentContract
    {
        public required string Name { get; set; }
        public required string UniqueNumber { get; set; }
        public bool CanAssignQuantity { get; set; }
        public int? Quantity { get; set; }
    }
}