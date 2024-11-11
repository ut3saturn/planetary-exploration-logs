using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscoveryType
{
    public class UpdateDiscovery_Handler : HandlerBase<int>
    {
        private readonly DiscoveryType _discoveryType;
        public UpdateDiscovery_Handler(PlanetExplorationDbContext context, DiscoveryType discoveryType) : base(context)
        {
            _discoveryType = discoveryType;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var existingDiscovery = await DbContext.DiscoveryTypes.FindAsync(_discoveryType.Id);

            if (existingDiscovery != null)
            {
                existingDiscovery.Name = _discoveryType.Name;
                existingDiscovery.Description = _discoveryType.Description;

                DbContext.DiscoveryTypes.Update(existingDiscovery);
                await DbContext.SaveChangesAsync();
            }

            var requestResult = new RequestResult<int>
            {
                Data = _discoveryType.Id,
                StatusCode = HttpStatusCode.OK
            };

            return requestResult;
        }
    }
}