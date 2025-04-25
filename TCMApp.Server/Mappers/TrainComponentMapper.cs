using TCMApp.Server.Core.Contracts;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;

namespace TCMApp.Server.Mappers;

public class TrainComponentMapper : IMapper<TrainComponent, TrainComponentContract>
{
    public TrainComponentContract Map(TrainComponent source)
    {
        return new TrainComponentContract
        {
            Id = source.Id,
            Name = source.Name,
            UniqueNumber = source.UniqueNumber,
            CanAssignQuantity = source.CanAssignQuantity,
            Quantity = source.CanAssignQuantity ? source.Quantity : null
        };
    }
}
