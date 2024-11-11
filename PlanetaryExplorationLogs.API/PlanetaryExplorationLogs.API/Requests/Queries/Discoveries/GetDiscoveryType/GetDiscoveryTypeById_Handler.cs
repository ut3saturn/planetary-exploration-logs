using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypeById
{
    public class GetDiscoveryTypeById_Handler : HandlerBase<DiscoveryType>
    {
        private readonly int _id;
        public GetDiscoveryTypeById_Handler(PlanetExplorationDbContext context, int id) : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult<DiscoveryType>> HandleAsync()
        {
            var discovery = await DbContext.DiscoveryTypes
                .Where(t => t.Id == _id)
                .FirstOrDefaultAsync();

            var result = new RequestResult<DiscoveryType>
            {
                Data = discovery,
            };

            return result;
        }
    }    
}
