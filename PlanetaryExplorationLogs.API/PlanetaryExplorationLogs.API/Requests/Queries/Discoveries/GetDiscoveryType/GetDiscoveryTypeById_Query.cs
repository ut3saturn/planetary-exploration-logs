using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypeById
{
    public class GetDiscoveryTypeById_Query : RequestBase<DiscoveryType>
    {
        public int Id { get; }
        public GetDiscoveryTypeById_Query(PlanetExplorationDbContext context, int id) : base(context)
        {
            Id = id;
        }

        public override IHandler<DiscoveryType> Handler => new GetDiscoveryTypeById_Handler(DbContext, Id);
    }    
}
