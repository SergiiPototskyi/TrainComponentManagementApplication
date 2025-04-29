using TCMApp.Application.UseCases.Models;
using TCMApp.Core.Entities;
using TCMApp.Core.Interfaces;

namespace TCMApp.Application.Mappers
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
