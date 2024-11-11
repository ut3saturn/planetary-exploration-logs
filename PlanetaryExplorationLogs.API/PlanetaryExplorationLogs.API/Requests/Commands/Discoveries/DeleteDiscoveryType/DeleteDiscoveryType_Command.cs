using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscoveryType
{
    public class DeleteDiscovery_Query : RequestBase<int>
    {
        private int Id { get; }
    
        public DeleteDiscovery_Query(PlanetExplorationDbContext context, int id) : base(context)
        {
            Id = id;
        }

        public override IValidator Validator => new DeleteDiscoveryType_Validator(DbContext, Id);
        public override IHandler<int> Handler => new DeleteDiscoveryType_Handler(DbContext, Id);
    }   
}
