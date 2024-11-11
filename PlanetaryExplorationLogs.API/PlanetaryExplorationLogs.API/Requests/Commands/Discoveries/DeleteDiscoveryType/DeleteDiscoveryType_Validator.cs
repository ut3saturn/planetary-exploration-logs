using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscoveryType
{
    public class DeleteDiscoveryType_Validator : ValidatorBase
    {
        private readonly int _id;

        public DeleteDiscoveryType_Validator(PlanetExplorationDbContext context, int id) : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            await Task.CompletedTask;

            if (!await DbContext.DiscoveryTypes.AnyAsync(dt => dt.Id == _id))
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    $"DiscoveryType not found with ID {_id}");
            }

            return await ValidResultAsync();
        }
    }    
}

