using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.UseCases.Models;

namespace TCMApp.Server.Mappers
{
    public class TrainComponentMapper : IMapper<TrainComponent, TrainComponentResponse>
    {
        public TrainComponentResponse Map(TrainComponent source)
        {
            return new TrainComponentResponse
            {
                Id = source.Id,
                Name = source.Name,
                UniqueNumber = source.UniqueNumber,
                CanAssignQuantity = source.CanAssignQuantity,
                Quantity = source.CanAssignQuantity ? source.Quantity : null
            };
        }
    }
}
