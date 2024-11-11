using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscoveryType
{
    public class DeleteDiscoveryType_Handler : HandlerBase<int>
    {
        private readonly int _id;

        public DeleteDiscoveryType_Handler(PlanetExplorationDbContext context, int id) : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var discoveryType = await DbContext.DiscoveryTypes.FindAsync(_id);
            
            if (discoveryType != null)
            {
             
                DbContext.DiscoveryTypes.Remove(discoveryType);
                await DbContext.SaveChangesAsync();
            }

            var result = new RequestResult<int>
            {
                Data = 0,
                StatusCode = HttpStatusCode.OK
            };

            return result;
        }
    }
}
