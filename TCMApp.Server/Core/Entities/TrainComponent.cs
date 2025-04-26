using TCMApp.Server.Core.BuildingBlocks;
using TCMApp.Server.Core.Interfaces;

namespace TCMApp.Server.Core.Entities
{
    public class TrainComponent : Entity, IAggregateRoot
    {
        public string Name { get; private set; } = null!;
        public string UniqueNumber { get; private set; } = null!;
        public bool CanAssignQuantity { get; private set; }
        public int? Quantity { get; private set; }

        public TrainComponent()
        {
        }
     
        public TrainComponent(
            string name,
            string uniqueNumber,
            bool canAssignQuantity,
            int? quantity = null)
        {
            Name = name;
            UniqueNumber = uniqueNumber;
            CanAssignQuantity = canAssignQuantity;
            Quantity = quantity;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetUniqueNumber(string uniqueNumber)
        {
            UniqueNumber = uniqueNumber;
        }

        public void AssignQuantity(bool canAssignQuantity, int? quantity)
        {
            CanAssignQuantity = canAssignQuantity;
            if (CanAssignQuantity)
            {
                Quantity = quantity;
            }
        }
    }
}
