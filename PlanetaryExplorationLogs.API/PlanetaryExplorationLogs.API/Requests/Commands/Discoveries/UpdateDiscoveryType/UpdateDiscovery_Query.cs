using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscoveryType
{
    public class UpdateDiscovery_Query : RequestBase<int>
    {
        private DiscoveryType Discovery { get; }
    
        public UpdateDiscovery_Query(PlanetExplorationDbContext context, DiscoveryType discovery) : base(context)
        {
            Discovery = discovery;
        }

        public override IValidator Validator => new UpdateDiscovery_Validator(DbContext, Discovery);
        public override IHandler<int> Handler => new UpdateDiscovery_Handler(DbContext, Discovery);
    }
}
