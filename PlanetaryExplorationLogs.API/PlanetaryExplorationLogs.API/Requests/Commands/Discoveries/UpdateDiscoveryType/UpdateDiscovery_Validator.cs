using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscoveryType
{
    public class UpdateDiscovery_Validator : ValidatorBase
    {
        private readonly DiscoveryType _discoveryType;

        public UpdateDiscovery_Validator(PlanetExplorationDbContext context, DiscoveryType discoveryType) :
            base(context)
        {
            _discoveryType = discoveryType;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            await Task.CompletedTask;
            
            if (!await DbContext.DiscoveryTypes.AnyAsync(dt => dt.Id == _discoveryType.Id))
            {
                return await InvalidResultAsync(HttpStatusCode.BadRequest, "Discovery type not found");
            }

            return await ValidResultAsync();
        }
    }
}
